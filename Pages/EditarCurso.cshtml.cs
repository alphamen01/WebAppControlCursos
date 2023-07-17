using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
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
        public async Task<IActionResult> OnGet(int id)
        {
            var course= await coursesProvider.GetAsync(id);
            if (course!=null)
            {
                Course = course;
            }

            return Page();
        }
        public async Task<IActionResult> OnPost() {

            if (!ModelState.IsValid)
            {
                return Page();
            }

           var result = await coursesProvider.UpdateAsync(Course.Id, Course);
            if (result)
            {
                return RedirectToPage("Cursos");
            }

            return Page();
        }
    }
}
