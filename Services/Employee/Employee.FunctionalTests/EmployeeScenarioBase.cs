using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using FADY.BuildingBlocks.IntegrationEventLogEF;

using FADY.Services.Employee.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using System.Reflection;
using FADY.Employee.API;
using FADY.Employee.API.Infrastructure;

namespace Employee.FunctionalTests
{
    public class EmployeeScenarioBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(EmployeeScenarioBase))
                .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables();
                }).UseStartup<EmployeeTestsStartup>();

            var testServer = new TestServer(hostBuilder);

            testServer.Host
                .MigrateDbContext<EmployeeContext>((context, services) =>
                {
                    var env = services.GetService<IWebHostEnvironment>();
                    var settings = services.GetService<IOptions<EmployeeSettings>>();
                    var logger = services.GetService<ILogger<EmployeeContextSeed>>();

                    new EmployeeContextSeed()
                        .SeedAsync(context, env, settings, logger)
                        .Wait();
                })
                .MigrateDbContext<IntegrationEventLogContext>((_, __) => { });

            return testServer;
        }

        public static class Get
        {
            public static string Employees = "api/Employee";
            public static string EmployeesById(int id) { return $"api/Employee/{id}";}
        }
        public static class Post
        {
      public static string Employees = "api/Employee";
     
        }
        public static class PutAsync
        {
            public static string Employees = "api/Employee";

        }
        public static class DeleteAsync
        {
            public static string Employees = "api/Employee";

        }
    }
}
