using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpenDHS.Shared.Data;
using OpenDHS.Web.Data;

namespace OpenDHS.Web.Areas.Manage.Pages.History
{
    public class DeleteModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;

        public DeleteModel(OpenDHS.Web.Data.OpenDHSDataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public HistoryEntity HistoryEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.History == null)
            {
                return NotFound();
            }

            var historyentity = await _context.History.FirstOrDefaultAsync(m => m.ID == id);

            if (historyentity == null)
            {
                return NotFound();
            }
            else 
            {
                HistoryEntity = historyentity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.History == null)
            {
                return NotFound();
            }
            var historyentity = await _context.History.FindAsync(id);

            if (historyentity != null)
            {
                HistoryEntity = historyentity;
                _context.History.Remove(HistoryEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
