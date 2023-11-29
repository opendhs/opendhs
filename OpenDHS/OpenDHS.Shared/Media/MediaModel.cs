using Microsoft.AspNetCore.Http;

namespace Opensalus.Shared
{
    public class MediaModel
    {
        public Guid Uuid { get; set; }
        public bool IsPublic { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
    
    }
}
