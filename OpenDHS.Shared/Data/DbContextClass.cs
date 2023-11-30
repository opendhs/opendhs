using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenDHS.Shared.Data;

namespace OpenDHS.Shared
{
    public class DbContextClass : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserEntity>().ToTable("Users");
            builder.Entity<RoleEntity>().ToTable("Roles");

            base.OnModelCreating(builder);
        }
        
        public DbSet<MediaEntity> FileDetails { get; set; }
    }
}

