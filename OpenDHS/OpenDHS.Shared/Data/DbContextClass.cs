using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Opensalus.Shared
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration? Configuration;

        public string DbPath { get; }

        public DbContextClass()
        {
            DbPath = Path.Combine(Environment.CurrentDirectory, "opensalus-development.db");
        }

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
            DbPath = Path.Combine(Environment.CurrentDirectory, "opensalus-development.db");
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

        public DbSet<MediaEntity> FileDetails { get; set; }
    }
}

