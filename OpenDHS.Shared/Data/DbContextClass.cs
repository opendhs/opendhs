using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OpenDHS.Shared.Data;


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
            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
            ChangeTracker.Tracked += ChangeTracker_StateChanged;
        }


        private void ChangeTracker_StateChanged(object? sender, EntityEntryEventArgs e)
        {
            if (e.Entry.Entity is IHasTimestamps entityWithTimestamps)
            {
                switch (e.Entry.State)
                {
                    case EntityState.Deleted:
                        entityWithTimestamps.DeletedAt = DateTime.UtcNow;
                        Console.WriteLine($"Stamped for delete: {e.Entry.Entity}");
                        break;
                    case EntityState.Modified:
                        entityWithTimestamps.UpdatedAt = DateTime.UtcNow;
                        Console.WriteLine($"Stamped for update: {e.Entry.Entity}");
                        break;
                    case EntityState.Added:
                        entityWithTimestamps.AddedAt = DateTime.UtcNow;
                        Console.WriteLine($"Stamped for insert: {e.Entry.Entity}");
                        break;
                }
            }
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

            builder.Entity<BlockEntity>().ToTable("Blocks");
        }
        
        public DbSet<MediaEntity> Medias { get; set; }
    }

}

