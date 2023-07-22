using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppControlCursos.Interfaces;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Providers
{
    public class FakeCoursesProvider : ICoursesProvider
    {
        private readonly List<Course> repo = new List<Course>();
        public FakeCoursesProvider()
        {
            repo.Add(new Course()
            {
                Id = 1,
                Name = "Sistemas Operativos",
                Author= "Luis Sanchez",
                Description= "Tecnologia",
                Uri = "https://github.com/alphamen01"
            });

            repo.Add(new Course()
            {
                Id = 2,
                Name = "Java",
                Author = "Luis Geronimo",
                Description = "Programacion",
                Uri = "https://github.com/alphamen01"
            });

            repo.Add(new Course()
            {
                Id = 3,
                Name = "C#",
                Author = "Luis Tejada",
                Description = "Programacion",
                Uri = "https://github.com/alphamen01"
            });

        }

        public Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
        {
            course.Id = repo.Max(c => c.Id) + 1; 
            repo.Add(course);
            return Task.FromResult((true, (int?)course.Id));
        }

		public Task<Course> DeleteAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task<ICollection<Course>> GetAllAsync()
        {
            return Task.FromResult((ICollection<Course>)repo.ToList());
        }

        public Task<Course> GetAsync(int id)
        {
            return Task.FromResult(repo.FirstOrDefault(c => c.Id == id));
        }

        public Task<ICollection<Course>> SearchAsync(string search)
        {
            return Task.FromResult((ICollection<Course>)repo.Where(c => c.Name.ToLowerInvariant().Contains(search.ToLowerInvariant())).ToList());
        }

        public Task<bool> UpdateAsync(int id, Course course)
        {
            var courseToUpdate = repo.FirstOrDefault(c => c.Id == id);
            if (courseToUpdate != null)
            {
                courseToUpdate.Name = course.Name;
                courseToUpdate.Description = course.Description;
                courseToUpdate.Author = course.Author;
                courseToUpdate.Uri = course.Uri;

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
