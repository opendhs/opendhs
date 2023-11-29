using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenDHS.Web.Pages
{
    public class RegisterModel : BasePageModel
    {
        public void OnGet()
        {
            Title = "Register";
            Message = "OnGet";
        }

        public IActionResult OnPostRegister()
        {
            Message = "OnPostRegister";
            Thread.Sleep(1000); // Only for demo proposuses
            return RedirectToPage("./Login");
        }
    }
}
