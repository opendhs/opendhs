using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDHS.Shared.Data
{
    public class HistoryEntity : BaseEntity
    {
        public required string UserName { get; set; }
        public required string UserId { get; set; }
        public required string Entity { get; set; }
        public required string Description { get; set; }

    }
}
