using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OpenDHS.Shared.Data
{
    public class UserEntity : IdentityUser<Guid>, IHasTimestamps
    {
        DateTime? IHasTimestamps.AddedAt { get; set;  } = DateTime.UtcNow;
        DateTime? IHasTimestamps.UpdatedAt { get; set; } = DateTime.UtcNow;
        DateTime? IHasTimestamps.DeletedAt { get; set; } = DateTime.UtcNow;
    }
}
