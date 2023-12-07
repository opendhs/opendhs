using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenDHS.Shared.Data;
using OpenDHS.Web.Data;

namespace OpenDHS.Web.Areas.Manage.Pages.History
{
    public class CreateModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;

        public CreateModel(OpenDHS.Web.Data.OpenDHSDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HistoryEntity HistoryEntity { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.History == null || HistoryEntity == null)
            {
                return Page();
            }
            
            HistoryEntity.AddedAt = DateTime.Now.ToUniversalTime();
            HistoryEntity.UpdatedAt = DateTime.Now.ToUniversalTime();

            _context.History.Add(HistoryEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
