using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Pages
{
    public class EditarCursoModel : PageModel
    {
        [BindProperty]
        public Course Course { get; set; }
        public void OnGet()
        {
        }
        public void OnPost() { 
        
        }
    }
}
