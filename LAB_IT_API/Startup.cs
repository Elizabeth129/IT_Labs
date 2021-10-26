using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB_IT_API.Controllers;
using LAB_IT_API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LAB_IT_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(opt =>
                  opt.UseSqlServer(Configuration.GetConnectionString("default")));
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<IHateoasDatabaseLinkGenerator, HateoasDatabaseLinkGenerator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "databases",
                    pattern: "api/databases/{dbName?}",
                    defaults: new { controller = "Databases" });
                endpoints.MapControllerRoute(
                    name: "tables",
                    pattern: "databases/{dbName}/tables/{tableName?}",
                    defaults: new { controller = "Tables" });
            });
        }
    }
}
