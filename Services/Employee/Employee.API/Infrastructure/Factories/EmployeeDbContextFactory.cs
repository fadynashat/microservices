using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FADY.Services.Employee.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Employee.API.Infrastructure.Factories
{
    public class EmployeeDbContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
    {
        public EmployeeContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();

            optionsBuilder.UseSqlServer(config["ConnectionString"], sqlServerOptionsAction: o => o.MigrationsAssembly("Employee.API"));

            return new EmployeeContext(optionsBuilder.Options);
        }
    }
}