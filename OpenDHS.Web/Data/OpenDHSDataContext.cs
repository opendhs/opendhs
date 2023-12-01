using Microsoft.EntityFrameworkCore;
using OpenDHS.Shared;

namespace OpenDHS.Web.Data;

public class OpenDHSWebContext : DbContextClass
{
    
    public OpenDHSWebContext(DbContextOptions<OpenDHSWebContext> options)
       : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=opendhs-development-migrations;Username=postgres;Password=postgres");
        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}