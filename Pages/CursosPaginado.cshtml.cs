using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppControlCursos.Interfaces;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Pages
{
    public class CursosPaginadoModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;

        [BindProperty]
        public Pager PagerCourses { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public CursosPaginadoModel(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }
        public async Task<IActionResult> OnGet(int pager=1, int size=3)
        {
            if (!string.IsNullOrWhiteSpace(Search))
            {
                var results = await coursesProvider.SearchAsyncPaginado(Search);
                if (results != null && results.Courses.Count > 0)
                {
                    PagerCourses = results;
                }
                else
                {
                    PagerCourses =null;
                }
            }
            else
            {
                var results = await coursesProvider.GetAllAsyncPaginado(pager, size);

                if (results != null && results.Courses.Count > 0)
                {
                    PagerCourses = (Pager)results;
                }
                else
                {
                    PagerCourses = null;
                }
            }
            /*var results = await coursesProvider.GetAllAsyncPaginado(pager, size);
            if (results != null)
            {
                PagerCourses = results;
                return Page();

            }
            return null;*/
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var course = await coursesProvider.EliminarAsync(id);
            if (course == null)
            {
                Mensaje = "Curso eliminado correctamente.";
                return RedirectToPage("CursosPaginado");
            }
            return null;
        }
    }
}
