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
    public class DeleteModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;

        public DeleteModel(OpenDHS.Web.Data.OpenDHSDataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.DataBlocks == null)
            {
                return NotFound();
            }
            var datablockentity = await _context.DataBlocks.FindAsync(id);

            if (datablockentity != null)
            {
                DataBlockEntity = datablockentity;
                _context.DataBlocks.Remove(DataBlockEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
