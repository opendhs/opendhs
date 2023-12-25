using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpenDHS.Shared.Data;
using OpenDHS.Web.Data;

namespace OpenDHS.Web.Areas.Manage.Pages.Role
{
    public class DeleteModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;

        public DeleteModel(OpenDHS.Web.Data.OpenDHSDataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public RoleEntity RoleEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var roleentity = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);

            if (roleentity == null)
            {
                return NotFound();
            }
            else 
            {
                RoleEntity = roleentity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }
            var roleentity = await _context.Roles.FindAsync(id);

            if (roleentity != null)
            {
                RoleEntity = roleentity;
                _context.Roles.Remove(RoleEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
