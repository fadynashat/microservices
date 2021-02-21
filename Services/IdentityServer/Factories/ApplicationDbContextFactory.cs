using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FADY.Services.IdentityServer.API.Data;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace IdentityServer.API.Factories
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(config["ConnectionString"], sqlServerOptionsAction: o => o.MigrationsAssembly("IdentityServer.API"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}