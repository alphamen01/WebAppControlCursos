using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Interfaces
{
	public interface IMaterialsProvider
	{
		Task<ICollection<Material>> GetAllMaterialsAsync(int id);
        Task<PagerMaterial> GetAllMaterialsAsyncPaginado(int id, int pager, int size);
    }
}
