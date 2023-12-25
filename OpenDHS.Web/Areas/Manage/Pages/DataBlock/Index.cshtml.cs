using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpenDHS.Shared.Data;
using OpenDHS.Web.Data;

namespace OpenDHS.Web.Areas.Manage.Pages.DataBlock
{
    public class IndexModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;

        public IndexModel(OpenDHS.Web.Data.OpenDHSDataContext context)
        {
            _context = context;
        }

        public IList<DataBlockEntity> DataBlockEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DataBlocks != null)
            {
                DataBlockEntity = await _context.DataBlocks.ToListAsync();
            }
        }
    }
}
