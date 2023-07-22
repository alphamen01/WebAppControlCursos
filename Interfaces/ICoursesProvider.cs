
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Interfaces
{
    public interface ICoursesProvider
    {
        Task<ICollection<Course>> GetAllAsync();
        Task<ICollection<Course>> SearchAsync(string search);
        Task<Course> GetAsync(int id);

        Task<bool> UpdateAsync(int id, Course  course);

        Task<(bool IsSuccess, int? Id)> AddAsync(Course course);

		Task<Course> DeleteAsync(int id);

	}
}
