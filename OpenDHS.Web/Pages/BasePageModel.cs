using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenDHS.Web.Pages
{

    public class BasePageModel : PageModel
    {
        [ViewData]
        public string Title { get; set; } = "Welcome";

        public string Message { get; set; } = "Handler called";
    }
}
