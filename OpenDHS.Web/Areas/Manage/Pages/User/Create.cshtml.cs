using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenDHS.Shared.Data;
using OpenDHS.Web.Data;

namespace OpenDHS.Web.Areas.Manage.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly OpenDHS.Web.Data.OpenDHSDataContext _context;
        private readonly UserManager<UserEntity> _userManager;
       
        public CreateModel(OpenDHS.Web.Data.OpenDHSDataContext context, UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult OnGet()
        {

            return Page();
        }

        [BindProperty]
        public UserPageModel Model { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Users == null || Model == null)
            {
                return Page();
            }

            // Teniendo las anotaciones compare esto no se debe verificar nunca! 
            if (Model.Password != Model.PasswordConfirm) {
                return Page();
            }

            //TODO: Terminar la logica y control de errores

            var _user = Activator.CreateInstance<UserEntity>();
            _user.Email = Model.Email;
            _user.Name = Model.Name;
            _user.Lastname = Model.Lastname;

            var result = await _userManager.CreateAsync(_user, Model.Password);


            _context.Users.Add(_user);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
