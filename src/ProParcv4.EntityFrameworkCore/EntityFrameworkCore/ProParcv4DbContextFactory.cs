using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProParcv4.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ProParcv4DbContextFactory : IDesignTimeDbContextFactory<ProParcv4DbContext>
{
    public ProParcv4DbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        ProParcv4EfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<ProParcv4DbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new ProParcv4DbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ProParcv4.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
