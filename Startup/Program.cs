using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Startup.Models;

namespace Startup
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }
        public static IHostingEnvironment Environment { get; set; }
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configBuilder) =>
            {
                Environment = hostContext.HostingEnvironment;
                Configuration = configBuilder.Build();
            })
            .ConfigureServices(services =>
            {
                services.AddTransient<IStartupFilter, RequestSetOptionStartupFilter>();
            })
            .ConfigureServices(services =>
            {
                services.AddMvc();
            })
            .Configure(app =>
            {
                if (Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseHttpsRedirection();
                app.UseCookiePolicy();
                app.UseFileServer();
                app.UseMvc(routes =>
                {
                    routes.MapRoute("default", "{controller}/{action}/{id?}");
                });
                //app.Run(async (context) =>
                //{
                //    await context.Response.WriteAsync("Hello World!!!");
                //});
            })
            ;
    }
}
