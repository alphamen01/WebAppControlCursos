
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Interfaces
{
    public interface ICoursesProvider
    {
        Task<ICollection<Course>> GetAllAsync();
        Task<Course> GetAsync(int id);
        
    }
}
