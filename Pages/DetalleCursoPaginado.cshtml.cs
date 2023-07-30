using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppControlCursos.Interfaces;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Pages
{
    public class DetalleCursoPaginadoModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;
        private readonly IMaterialsProvider materialsProvider;
        public Course Course { get; set; }

        [BindProperty]
        public PagerMaterial PagerMaterials { get; set; }

        public DetalleCursoPaginadoModel(ICoursesProvider coursesProvider, IMaterialsProvider materialsProvider)
        {
            this.coursesProvider = coursesProvider;
            this.materialsProvider = materialsProvider;
        }
        public async Task<IActionResult> OnGet(int id, int pager= 1, int size=3)
        {
            var course = await coursesProvider.GetAsync(id);
            var results = await materialsProvider.GetAllMaterialsAsyncPaginado(id,pager,size);
            if (course != null || (results != null && results.Materials.Count> 0))
            {
                Course = course;

                if (results != null && results.Materials.Count > 0)
                {
                    PagerMaterials = (PagerMaterial)results;
                }
                else
                {
                    PagerMaterials = null;
                }

                return Page();

            }

            return RedirectToPage("CursosPaginado");
            /*
            if (course != null)
            {
                Course = course;
                return Page();
            }

            return RedirectToPage("CursosPaginado");*/
        }
    }
}
