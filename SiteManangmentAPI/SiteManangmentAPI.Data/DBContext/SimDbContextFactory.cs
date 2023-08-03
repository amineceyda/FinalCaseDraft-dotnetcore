using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SiteManangmentAPI.Data.DBContext;

public class SimDbContextFactory : IDesignTimeDbContextFactory<SimDbContext>
{
    public SimDbContext CreateDbContext(string[] args)
    {
        // Load appsettings.json or appsettings.{Environment}.json
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var dbType = configuration.GetConnectionString("DbType");
        if (dbType == "MsSql")
        {
            var optionsBuilder = new DbContextOptionsBuilder<SimDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MsSqlConnection"));
            return new SimDbContext(optionsBuilder.Options);
        }

        throw new NotSupportedException($"Database type '{dbType}' is not supported.");
    }
}
