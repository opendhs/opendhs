using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpenDHS.Shared.Data;
using OpenDHS.Web.Data;

namespace OpenDHS.Web.Areas.Manage.Pages.DataContainer
{
    public class DeleteModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;

        public DeleteModel(OpenDHS.Web.Data.OpenDHSDataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DataContainerEntity DataContainerEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.DataContainers == null)
            {
                return NotFound();
            }

            var datacontainerentity = await _context.DataContainers.FirstOrDefaultAsync(m => m.ID == id);

            if (datacontainerentity == null)
            {
                return NotFound();
            }
            else 
            {
                DataContainerEntity = datacontainerentity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.DataContainers == null)
            {
                return NotFound();
            }
            var datacontainerentity = await _context.DataContainers.FindAsync(id);

            if (datacontainerentity != null)
            {
                DataContainerEntity = datacontainerentity;
                _context.DataContainers.Remove(DataContainerEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
