using OpenDHS.Shared.Data;
using System.ComponentModel.DataAnnotations;


namespace OpenDHS.Shared
{
    public class MediaEntity : BaseEntity
    {
        
        [Required]
        public Guid Uuid { get; set; }
        public bool IsPublic { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
        public MediaType FileType { get; set; }
    }
}
