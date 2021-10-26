using LAB_IT_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace LAB_IT_API.Controllers
{
    public interface IHateoasDatabaseLinkGenerator
    {
        public IEnumerable<Link> CreateLinksForDatabase(HttpContext context, string name);
        public LinkCollectionWrapper<DatabasesController.DatabaseViewWithLinks> CreateLinksForDatabases(HttpContext context, LinkCollectionWrapper<DatabasesController.DatabaseViewWithLinks> databasesWrapper);

    }
    public class HateoasDatabaseLinkGenerator : IHateoasDatabaseLinkGenerator
    {
        LinkGenerator _linkGenerator;
        public HateoasDatabaseLinkGenerator(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }
        public IEnumerable<Link> CreateLinksForDatabase(HttpContext context, string name)
        {
            var links = new List<Link>
            {
                new Link(
                    _linkGenerator.GetUriByAction(context, nameof(DatabasesController.GetDatabase), values: new { name }),
                    "self",
                    "GET"
                ),
                new Link(
                    _linkGenerator.GetUriByAction(context, nameof(DatabasesController.DeleteDatabase), values: new { name }),
                    "delete_database",
                    "DELETE"
                ),
                new Link(
                    _linkGenerator.GetUriByAction(context, nameof(DatabasesController.PutDatabase), values: new { name }),
                    "update_database",
                    "PUT"
                ),
                new Link(
                    _linkGenerator.GetUriByAction(context, nameof(TablesController.GetTables), controller: "Tables", values: new { dbName = name }),
                    "show_tables",
                    "GET"
                ),
                //new Link(
                //    _linkGenerator.GetUriByAction(context, nameof(TablesController.JoinTables), controller: "Tables", values: new { dbName = name }),
                //    "table_join",
                //    "POST"
                //)
            };
            return links;

        }
        public LinkCollectionWrapper<DatabasesController.DatabaseViewWithLinks> CreateLinksForDatabases(HttpContext context, LinkCollectionWrapper<DatabasesController.DatabaseViewWithLinks> databasesWrapper)
        {
            databasesWrapper.Links.Add(
                new Link(_linkGenerator.GetUriByAction(context, nameof(DatabasesController.GetDatabases), values: new { }),
                    "self",
                    "GET"));
            databasesWrapper.Links.Add(
                new Link(
                    _linkGenerator.GetUriByAction(context, nameof(DatabasesController.PostDatabase), values: new { }),
                    "create_database",
                    "POST"));
            return databasesWrapper;
        }

    }
    [Route("api/databases")]
    [ApiController]
    public class DatabasesController : ControllerBase
    {
        private readonly IDatabaseService _context;
        private IHateoasDatabaseLinkGenerator _linkGenerator;
        public DatabasesController(IDatabaseService context, IHateoasDatabaseLinkGenerator linkGenerator)
        {
            _context = context;
            _linkGenerator = linkGenerator;
        }
        public class DatabaseView
        {
            public class DatabaseTableView
            {
                public string name;
                public int rowsCount;
            }
            public string name;
            public ICollection<DatabaseTableView> tables;
        }
        public class DatabaseViewWithLinks : DatabaseView
        {
            [JsonProperty(Order = 1)]
            public IEnumerable<Link> links;
        }

        // GET: api/databases
        [HttpGet]
        public async Task<IActionResult> GetDatabases()
        {
            var allDatabases = await _context.GetDatabases();
            var databases = allDatabases
                .Select(d => new DatabaseViewWithLinks
                {
                    name = d.Name,
                    tables = d.Tables
                        .Select(t => new DatabaseView.DatabaseTableView
                        {
                            name = t.Name,
                            rowsCount = t.Data.Count
                        })
                        .ToList()
                })
                .ToList();
            for (int i = 0; i < databases.Count; i++)
            {
                databases[i].links = _linkGenerator.CreateLinksForDatabase(HttpContext, databases[i].name);
            }
            var databasesWrapper = new LinkCollectionWrapper<DatabaseViewWithLinks>(databases);
            return Ok(_linkGenerator.CreateLinksForDatabases(HttpContext, databasesWrapper));
        }

        // GET: api/databases/dbName
        [HttpGet("{name}")]
        public async Task<ActionResult<DatabaseViewWithLinks>> GetDatabase(string name)
        {
            var databases = await _context.GetDatabases();
            var database = databases
                .Where(d => d.Name == name)
                .Select(d => new DatabaseViewWithLinks
                {
                    name = d.Name,
                    tables = d.Tables
                        .Select(t => new DatabaseView.DatabaseTableView { name = t.Name, rowsCount = t.Data.Count })
                        .ToList()
                })
                .First();

            if (database == null)
            {
                return NotFound();
            }
            database.links = _linkGenerator.CreateLinksForDatabase(HttpContext, database.name);
            return database;
        }

        // PUT: api/databases/dbName
        [HttpPut("{name}")]
        public async Task<IActionResult> PutDatabase(string name, Database database)
        {
            int id = await _context.GetDatabaseId(name);
            if (id != database.Id)
            {
                return BadRequest();
            }

            try
            {
                await _context.UpdateDatabase(database);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DatabaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/databases
        [HttpPost]
        public async Task<ActionResult<Database>> PostDatabase(Database database)
        {
            await _context.CreateDatabase(database);
            return CreatedAtAction("GetDatabase", new { name = database.Name }, database);
        }

        // DELETE: api/databases/dbName
        [HttpDelete("{name}")]
        public async Task<ActionResult<Database>> DeleteDatabase(string name)
        {
            var databases = await _context.GetDatabases();
            var database = databases.Where(d => d.Name == name).First();
            if (database == null)
            {
                return NotFound();
            }

            await _context.DeleteDatabase(database);

            return database;
        }

        private async Task<bool> DatabaseExists(int id)
        {
            return await _context.DatabaseExists(id);
        }
    }
}
