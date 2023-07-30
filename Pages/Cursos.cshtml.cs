using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppControlCursos.Interfaces;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Pages
{
    public class CursosModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;
        
        public  List<Course> Courses { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public CursosModel(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }

        public async Task<IActionResult> OnGet()
        {
            if (!string.IsNullOrWhiteSpace(Search))
            {
                var results = await coursesProvider.SearchAsync(Search);
                if (results != null)
                {
                    Courses = new List<Course>(results);
                }
            }
            else
            {
                var results = await coursesProvider.GetAllAsync();
                if (results != null)
                {
                    Courses = new List<Course>(results);
                }
            }
            
            return Page ();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var course = await coursesProvider.EliminarAsync(id);
            if (course == null)
            {
                Mensaje = "Curso eliminado correctamente.";
                return RedirectToPage("Cursos");
            }
            return null;
        }
    }
}
