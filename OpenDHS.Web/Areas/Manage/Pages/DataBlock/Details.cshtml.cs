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
    public class DetailsModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;

        public DetailsModel(OpenDHS.Web.Data.OpenDHSDataContext context)
        {
            _context = context;
        }

      public DataBlockEntity DataBlockEntity { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.DataBlocks == null)
            {
                return NotFound();
            }

            var datablockentity = await _context.DataBlocks.FirstOrDefaultAsync(m => m.ID == id);
            if (datablockentity == null)
            {
                return NotFound();
            }
            else 
            {
                DataBlockEntity = datablockentity;
            }
            return Page();
        }
    }
}
