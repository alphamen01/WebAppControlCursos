using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Pages
{
    public class DetalleCursoModel : PageModel
    {
        public Course Course { get; set; }
        public void OnGet()
        {
            Course = new Course();
        }
    }
}
