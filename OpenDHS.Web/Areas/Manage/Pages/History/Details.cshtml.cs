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
    public class DetailsModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;

        public DetailsModel(OpenDHS.Web.Data.OpenDHSDataContext context)
        {
            _context = context;
        }

      public HistoryEntity HistoryEntity { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
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
    }
}
