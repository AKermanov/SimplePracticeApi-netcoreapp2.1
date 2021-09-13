using CityInfoAPI.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            logger.Info("Initializing application...");
            var host = CreateWebHostBuilder(args).Build();

            using (var scoup = host.Services.CreateScope())
            {
                try
                {
                    var context = scoup.ServiceProvider.GetService<CityInfoContext>();
                    //context.Database.EnsureDeleted();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Application stopped because of exception.");
                }
                finally
                {
                    NLog.LogManager.Shutdown();
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog();
    }
}
