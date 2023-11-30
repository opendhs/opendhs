using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenDHS.Web.Pages
{

    public class BasePageModel : PageModel
    {
        [ViewData]
        public string Title { get; set; } = "Welcome";

        [ViewData]
        public string MetaDescription { get; set; } = String.Empty;

        public string Message { get; set; } = "Handler called";
    }
}
