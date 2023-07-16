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
    }
}
