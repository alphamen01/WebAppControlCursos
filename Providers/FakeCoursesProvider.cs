using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public Task<Course> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
