using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using LAB_IT_API.Models;

namespace LAB_IT_API.Controllers
{
    [Route("api/databases/{dbName}/tables")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private LinkGenerator _linkGenerator;

        public TablesController(DatabaseContext context, LinkGenerator linkGenerator)
        {
            _context = context;
            _linkGenerator = linkGenerator;
        }

        public class ColumnDefinitionView
        {
            public string name;
            public ColumnType type;
        }
        public class TableView
        {
            public string name;
            public List<ColumnDefinition> columns;
            public int rowCount;
        }
        public class TableViewWithLinks : TableView
        {
            [JsonProperty(Order = 1)]
            public IEnumerable<Link> links;
        }

        public class TableWithDataView
        {
            public TableWithDataView()
            {
                columns = new List<ColumnDefinition>();
                data = new List<List<object>>();
            }
            public string name;
            public List<ColumnDefinition> columns;
            public List<List<object>> data;
            public List<Row> DataToRows()
            {
                List<Row> result = new List<Row>();
                for (int i = 0; i < data.Count; i++)
                {
                    result.Add(new Row(data.ElementAt(i)));
                }
                return result;
            }
        }
        public class TableWithDataViewWithLinks : TableWithDataView
        {
            [JsonProperty(Order = 1)]
            public IEnumerable<Link> links;
        }

        private IEnumerable<Link> CreateLinksForTable(string dbName, string tableName)
        {
            var links = new List<Link>
            {
                new Link(
                    _linkGenerator.GetUriByAction(HttpContext, nameof(GetTable), values: new { dbName, tableName }),
                    "self",
                    "GET"
                ),
                new Link(
                    _linkGenerator.GetUriByAction(HttpContext, nameof(DeleteTable), values: new { dbName, tableName }),
                    "delete_table",
                    "DELETE"
                ),
                new Link(
                    _linkGenerator.GetUriByAction(HttpContext, nameof(PutTable), values: new { dbName, tableName }),
                    "update_table",
                    "PUT"
                )
            };
            return links;
        }
        private LinkCollectionWrapper<TableViewWithLinks>
            CreateLinksForTables(LinkCollectionWrapper<TableViewWithLinks> databasesWrapper, string dbName)
        {
            databasesWrapper.Links.Add(
                new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetTables), values: new { dbName }),
                    "self",
                    "GET"));
            databasesWrapper.Links.Add(
                new Link(
                    _linkGenerator.GetUriByAction(HttpContext, nameof(PostTable), values: new { dbName }),
                    "create_table",
                    "POST"));
            return databasesWrapper;
        }

        // GET: api/databases/{dbName}/tables
        [HttpGet]
        public async Task<IActionResult> GetTables([FromRoute]string dbName)
        {
            var tables = await _context.Tables
                .Where(t => t.Parent.Name == dbName)
                .Select(t => new TableViewWithLinks
                {
                    name = t.Name,
                    columns = t.ColumnDefinitions,
                    rowCount = t.Data.Count
                })
                .ToListAsync();
            for (int i = 0; i < tables.Count; i++)
            {
                tables[i].links = CreateLinksForTable(dbName, tables[i].name);
            }
            var databasesWrapper = new LinkCollectionWrapper<TableViewWithLinks>(tables);
            return Ok(CreateLinksForTables(databasesWrapper, dbName));
        }

        // GET: api/databases/{dbName}/tables/{tableName}
        [HttpGet("{tableName}")]
        public async Task<ActionResult<TableWithDataViewWithLinks>> GetTable([FromRoute] string dbName, [FromRoute] string tableName)
        {
            var table = await _context.Tables
                .Where(t => t.Parent.Name == dbName && t.Name == tableName)
                .Include(t => t.Data)
                .ThenInclude(r => r.Elements)
                .Select(t => new TableWithDataViewWithLinks
                {
                    name = t.Name,
                    columns = t.ColumnDefinitions,
                    data = t.DataAsObjects()
                })
                .FirstAsync();
            table.links = CreateLinksForTable(dbName, tableName);
            if (table == null)
            {
                return NotFound();
            }

            return table;
        }

        // PUT: api/databases/{dbName}/tables/{tableName}
        [HttpPut("{tableName}")]
        public async Task<IActionResult> PutTable([FromRoute] string dbName, [FromRoute] string tableName, TableWithDataView tableView)
        {
            Database database = await _context.Databases.Where(d => d.Name == dbName).FirstAsync();
            if (database == null)
            {
                return BadRequest();
            }
            Table table = new Table()
            {
                Name = tableView.name,
                ParentId = database.Id,
                ColumnDefinitions = tableView.columns,
                Data = tableView.DataToRows()
            };
            int id = await _context.Tables.Include(t => t.Parent).Where(t => t.Parent.Name == dbName && t.Name == tableName).Select(t => t.Id).FirstAsync();
            table.Id = id;
            if (!table.ValidateData())
            {
                return BadRequest("Invalid data for table provided");
            }

            _context.Entry(table).Collection("Data").IsModified = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
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

        // POST: api/databases/{dbName}/tables
        [HttpPost]
        public async Task<ActionResult<TableWithDataView>> PostTable([FromRoute] string dbName, TableWithDataView tableView)
        {
            Database database = await _context.Databases.Where(d => d.Name == dbName).FirstAsync();
            if (database == null)
            {
                return BadRequest();
            }
            Table table = new Table()
            {
                Name = tableView.name,
                ParentId = database.Id,
                ColumnDefinitions = tableView.columns,
                Data = tableView.DataToRows()
            };
            if (!table.ValidateData())
            {
                return BadRequest("Invalid data for table provided");
            }
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTable", new { dbName, tableName = table.Name }, table);
        }

        // DELETE: api/databases/{dbName}/tables/{tableName}
        [HttpDelete("{tableName}")]
        public async Task<ActionResult<Table>> DeleteTable([FromRoute] string dbName, [FromRoute] string tableName)
        {
            var table = await _context.Tables.Where(t => t.Parent.Name == dbName && t.Name == tableName).FirstAsync();
            if (table == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return table;
        }

        private bool TableExists(int id)
        {
            return _context.Tables.Any(e => e.Id == id);
        }
    }
}
