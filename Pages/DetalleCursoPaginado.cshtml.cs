using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebAppControlCursos.Interfaces;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Pages
{
    public class DetalleCursoPaginadoModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;

        public Course Course { get; set; }

        public DetalleCursoPaginadoModel(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            var course = await coursesProvider.GetAsync(id);
            if (course != null)
            {
                Course = course;
                return Page();
            }

            return RedirectToPage("CursosPaginado");
        }
    }
}
