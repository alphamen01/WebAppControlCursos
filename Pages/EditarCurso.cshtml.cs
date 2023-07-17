using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppControlCursos.Interfaces;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Pages
{
    public class EditarCursoModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;

        [BindProperty]
        public Course Course { get; set; }

        public EditarCursoModel(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }
        public void OnGet()
        {
        }
        public void OnPost() { 
        
        }
    }
}
