using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _Config;

        public Startup(IConfiguration Config)
        {
            _Config = Config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                app.Use(async (context, next) =>
                {
                    logger.LogInformation("wm1: incoming Requst");
                    await next();
                    logger.LogInformation("wm1: out go ing message Requst");
                });

            });
            app.Use(async (context, next) =>
            {
                logger.LogInformation("wm2: incoming Requst");
                await next();
                logger.LogInformation("wm2SS: out go ing message Requst");
            });
            app.Use(async (context, next) =>
            {
                logger.LogInformation("wm3: incoming Requst");
                
                logger.LogInformation("wm3SS: out go ing message Requst");
            });


            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("2nd Hello word !");
                await next();
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("3nd Hello word !");
            });


        }
    }
}
