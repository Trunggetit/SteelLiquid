using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSwag.AspNetCore;
using SteelLiquid.DA.Interfaces;
using SteelLiquid.Entity;

namespace SteelLiquid.API
{
    public class Startup
    {
        //public Startup(IHostingEnvironment env)
        //{

        //    //var builder = new ConfigurationBuilder()
        //    //    .SetBasePath(env.ContentRootPath)
        //    //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //    //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //    //    .AddEnvironmentVariables();
        //    //Configuration = builder.Build();

        //}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //LoadDatabaseConnectionStrings();

            //services.AddMvcCore()
            //   .AddAuthorization()
            //   .AddJsonFormatters();

            //services.AddAuthentication("Bearer")
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = "https://webservice.mdpweb.net/identityserver";
            //        options.RequireHttpsMetadata = true;

            //        options.ApiName = "AnalyticsApi";
            //    });

            //services.AddResponseCompression();

            //services.AddCors();

            //// Add framework services.
            services.AddMvc()
                .AddSessionStateTempDataProvider();

            services.AddSession();

            //Register dependency injections
            Dependencies.Dependencies.Register(services);

            //// Add functionality to inject IOptions<T>
            //services.AddOptions();

            //services.AddSingleton<IConfiguration>(Configuration);

            //// Inject an implementation of ISwaggerProvider with defaulted settings applied
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Nextgen Analytics API", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = NJsonSchema.PropertyNameHandling.CamelCase;
            });

            var cs = app.ApplicationServices.GetService<IConnectionSettings>();
            cs.DefaultConnectionString = Configuration["ConnectionStrings:SqlDefaultDBName"];

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc();


        }

        //private void LoadDatabaseConnectionStrings()
        //{
        //    var csList = Configuration.GetSection("ConnectionStrings").GetChildren().Where(i => i.Key.EndsWith("Connection"));
        //    foreach (var cs in csList) DatabaseConnections.AddConectionString(cs.Key, cs.Value);

        //    DatabaseConnections.SqlDBServers = Configuration.GetConnectionString("SqlDBServers").Split(',').ToList();
        //    DatabaseConnections.MySqlDBServers = Configuration.GetConnectionString("MySqlDBServers").Split(',').ToList();

        //    DatabaseConnections.SqlDefaultDBName = Configuration.GetConnectionString("SqlDefaultDBName");
        //    DatabaseConnections.MySqlDefaultDBName = Configuration.GetConnectionString("MySqlDefaultDBName");
        //}
    }
}
