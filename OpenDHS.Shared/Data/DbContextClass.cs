using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenDHS.Shared.Data;

//IdentityDbContext<
//       ApplicationUser, ApplicationRole, string,
//       IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
//       IdentityRoleClaim<string>, IdentityUserToken<string>>

namespace OpenDHS.Shared
{
    public class DbContextClass
        : IdentityDbContext<UserEntity, RoleEntity, Guid,
        UserClaimEntity, UserRoleEntity, UserLoginEntity,
        RoleClaimEntity, UserTokenEntity>
    {
        public DbContextClass(DbContextOptions options)
      : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>().ToTable("Users");
            builder.Entity<UserClaimEntity>().ToTable("UserClaims");
            builder.Entity<UserLoginEntity>().ToTable("UserLogins");
            builder.Entity<UserRoleEntity>().ToTable("UserRoles");
            builder.Entity<UserTokenEntity>().ToTable("UserTokens");
            
            builder.Entity<RoleEntity>().ToTable("Roles");
            builder.Entity<RoleClaimEntity>().ToTable("RoleClaims");

            builder.Entity<MediaEntity>().ToTable("Medias");
        }
        
        public DbSet<MediaEntity> Medias { get; set; }
    }
}

