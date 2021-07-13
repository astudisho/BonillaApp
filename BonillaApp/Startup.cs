using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MySql.EntityFrameworkCore.Extensions;
using BonillaApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using BonillaApp.Data.Repository;
using BonillaApp.Mapper;
using BonillaApp.Bussines;

namespace BonillaApp
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Energia Eficiente", Version = "v1" });
            });

            //services.AddEntityFrameworkMySQL()
            //    .AddDbContext<MonitorContext>(options => 
            //    {
            //        //options.UseMySQL("server=a2nlmysql39plsk.secureserver.net;uid=innovus1;database=energia_eficiente;pwd=Guadalajara1*;persistsecurityinfo=True"); 
            //        options.UseMySQL("server=mysql;uid=root;database=energia_eficiente;pwd=Guadalajara1*");
            //    });
            services.AddDbContext<MonitorContext>(options =>
            {
                //options.UseMySQL("server=a2nlmysql39plsk.secureserver.net;uid=innovus1;database=energia_eficiente;pwd=Guadalajara1*");
                options.UseMySQL("server=162.241.62.160;uid=innovus1_monitor;database=innovus1_monitor;pwd=Guadalajara1*");
                //options.UseMySQL("server=mysql;uid=root;database=energia_eficiente;pwd=Guadalajara1*");

            }, ServiceLifetime.Scoped);

            services.AddAutoMapper(x => x.AddProfile(typeof(DefaultProfile)));

            // Dependency injection.
            services.AddScoped<VoltajeRepository>();
            services.AddScoped<DeviceRepository>();
            services.AddScoped<VoltajeService>();
            services.AddScoped<DeviceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, MonitorContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Energia Eficiente v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Ensure context is created.
            var pendingMigrations = dbContext.Database.GetPendingMigrations().Any();

            if (pendingMigrations)
            {
                await dbContext.Database.MigrateAsync();
            }
        }
    }
}
