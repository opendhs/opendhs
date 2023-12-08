using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDHS.Shared.Data
{
    public class PageContainerEntity : BaseEntity
    {
        public required string Title { get; set; }
        public required string MetaDescription { get; set; }
        public required string MetaKeywords { get; set; }

        public ICollection<DataBlockEntity> PageBlocks { get; } = new List<DataBlockEntity>();
    }
}
