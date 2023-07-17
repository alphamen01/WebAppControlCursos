using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebAppControlCursos.Interfaces;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Pages
{
    public class DetalleCursoModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;

        public Course Course { get; set; }

        public DetalleCursoModel(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }
        public async Task<ActionResult> OnGet(int id)
        {
            var course = await coursesProvider.GetAsync(id);
            if (course != null)
            {
                Course = course;
                return Page();
            }

            return RedirectToPage("Cursos");
        }
    }
}
