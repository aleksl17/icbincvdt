using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using icbincvdt.Data;
using icbincvdt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace icbincvdt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            CreateDbIfNotExists(host);

            host.Run();

        }
        
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    // Get our database context from the service provider
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var um = services.GetRequiredService<UserManager<ApplicationUser>>();
                    
                    // Get the environment so we can check if this is running in development or otherwise
                    var environment = services.GetService<IHostEnvironment>();
                    
                    // Initialise the database using the initializer.
                    DbInitializer.Initialize(context, um, environment.IsDevelopment());
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}