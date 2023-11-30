using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenDHS.Shared.Data;

namespace OpenDHS.Shared
{
    public class DbContextClass : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        protected readonly IConfiguration? Configuration;

        public string? DbPath { get; }

        public DbContextClass()
        {
            DbPath = Path.Combine(Environment.CurrentDirectory, "opendhs-development.db");
        }

        public DbContextClass(IConfiguration configuration)
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

        public DbSet<MediaEntity> FileDetails { get; set; }
    }
}

