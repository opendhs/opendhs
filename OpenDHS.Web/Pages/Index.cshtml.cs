using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OpenDHS.Web.Pages
{
    public class IndexModel : BasePageModel
    {
        public void OnGet()
        {
            this.Message = "Estoy renderizando el index";
        }
        public void OnPost()
        {

        }

        public void OnPostClick() {
            Message = "Di click en el boton";
            MetaDescription = "OpenDHS Index Page description";
        }
    }
}
