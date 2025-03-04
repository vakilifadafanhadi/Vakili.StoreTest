using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Vakili.StoreTest.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class StoreTestDbContextFactory : IDesignTimeDbContextFactory<StoreTestDbContext>
{
    public StoreTestDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        StoreTestEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<StoreTestDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new StoreTestDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Vakili.StoreTest.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
