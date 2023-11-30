using Microsoft.EntityFrameworkCore;

namespace OpenDHS.Web.Data;

public class OpenDHSDataContext : OpenDHS.Shared.DbContextClass
{
    private readonly IConfiguration? Configuration;

    public string? DbPath { get; }

    public OpenDHSDataContext()
    {
        DbPath = Path.Combine(Environment.CurrentDirectory, "opendhs-development.db");
    }

    public OpenDHSDataContext(IConfiguration configuration)
    {
        Configuration = configuration;
        DbPath = Path.Combine(Environment.CurrentDirectory, "opendhs-development.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        void DevelopmentSettings(DbContextOptionsBuilder options)
        {
            // options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            options.UseSqlite($"Data Source={DbPath}");
        }

        if (Configuration == null)
        {
            DevelopmentSettings(options);
            return;
        }
        var dbconnectiontring = Configuration?.GetConnectionString("DefaultConnection");
        if (dbconnectiontring == null)
        {
            DevelopmentSettings(options);
            return;
        }

        // options.UseNpgsql(dbconnectiontring);
        options.UseSqlite(dbconnectiontring);

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}