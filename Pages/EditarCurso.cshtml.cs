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
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                Course = new Course();
            }
            else
            {
                var course = await coursesProvider.GetAsync(id.Value);
                if (course != null)
                {
                    Course = course;
                }
            }        
            return Page();
        }
        public async Task<IActionResult> OnPost() {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Course.Id == 0)
            {
                var result = await coursesProvider.AddAsync(Course);
                if (result.IsSuccess)
                {
                    return RedirectToPage("Cursos");
                }
                return Page();
            }
            else
            {
                var result = await coursesProvider.UpdateAsync(Course.Id, Course);
                if (result)
                {
                    return RedirectToPage("Cursos");
                }
            }
            return Page();
        }
    }
}
