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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddSessionStateTempDataProvider();

            services.AddSession();

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            //Register dependency injections
            Dependencies.Dependencies.Register(services);
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

            DatabaseConnections.SqlDefaultDBName = Configuration.GetConnectionString("SqlDefaultDBName");
            DatabaseConnections.MySqlDefaultDBName = Configuration.GetConnectionString("MySqlDefaultDBName");


            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc();


        }
    }
}
