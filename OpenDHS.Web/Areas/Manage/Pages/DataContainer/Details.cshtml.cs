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
    public class DetailsModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;

        public DetailsModel(OpenDHS.Web.Data.OpenDHSDataContext context)
        {
            _context = context;
        }

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
    }
}
