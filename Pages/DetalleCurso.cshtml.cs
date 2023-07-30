using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppControlCursos.Interfaces;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Pages
{
    public class DetalleCursoModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;
		private readonly IMaterialsProvider materialsProvider;

		public Course Course { get; set; }

		public List<Material> Materials { get; set; }

		public DetalleCursoModel(ICoursesProvider coursesProvider, IMaterialsProvider materialsProvider)
        {
            this.coursesProvider = coursesProvider;
            this.materialsProvider = materialsProvider;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            /*var course = await coursesProvider.GetAsync(id);
            if (course != null)
            {
                Course = course;
                return Page();
            }

			var results = await materialsProvider.GetAllMaterialsAsync(id);
			if (results != null)
			{
				Materials = new List<Material>(results);
				return Page();
			}

			return RedirectToPage("Cursos");*/

            var course = await coursesProvider.GetAsync(id);
            var results = await materialsProvider.GetAllMaterialsAsync(id);
            if (course != null || (results != null && results.Count > 0))
            {

                Course = course;

                if (results != null && results.Count > 0)
                {
                    Materials = new List<Material>(results);
                }

                return Page();
            }

            return RedirectToPage("Cursos");
        }
    }
}
