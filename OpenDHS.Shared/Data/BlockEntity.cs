using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDHS.Shared.Data
{
    public class BlockEntity  : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }

        [Column(TypeName = "jsonb")]
        public required string Data { get; set; }
    }
}
