using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opensalus.Shared
{
    [Table("FileDetails")]
    public class MediaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public Guid Uuid { get; set; }
        public bool IsPublic { get; set; }
        public string? FileName { get; set; }
        public byte[]? FileData { get; set; }
        public MediaType FileType { get; set; }
    }
}
