using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OpenDHS.Shared.Data
{
    public class UserEntity : IdentityUser<Guid>, IHasTimestamps
    {
        public required string Name { get; set; }
        public required string Lastname { get; set; }

        public Guid MediaId { get; set; }
        public MediaEntity Avatar { get; set; } = null!;

        DateTime? IHasTimestamps.AddedAt { get; set;  } = DateTime.UtcNow;
        DateTime? IHasTimestamps.UpdatedAt { get; set; } = DateTime.UtcNow;
        DateTime? IHasTimestamps.DeletedAt { get; set; } = DateTime.UtcNow;
    }
}
