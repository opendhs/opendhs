using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenDHS.Web.Pages
{
    public class LoginModel : BasePageModel
    {
       
        public void OnGet()
        {
            Title = "Login";
            Message = "OnGet";
        }

        public IActionResult OnPostLogin()
        {
            Message = "OnPostLogin";
            Thread.Sleep(1000); // Only for demo proposuses
            return RedirectToPage("./Index");
        }
    }
}
