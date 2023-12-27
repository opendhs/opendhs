using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenDHS.Shared.Data;
using OpenDHS.Web.Data;

namespace OpenDHS.Web.Areas.Manage.Pages.DataContainer
{
    public class EditModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;

        public EditModel(OpenDHS.Web.Data.OpenDHSDataContext context)
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

            var datacontainerentity =  await _context.DataContainers.FirstOrDefaultAsync(m => m.ID == id);
            if (datacontainerentity == null)
            {
                return NotFound();
            }
            DataContainerEntity = datacontainerentity;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DataContainerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataContainerEntityExists(DataContainerEntity.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DataContainerEntityExists(Guid id)
        {
          return (_context.DataContainers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
