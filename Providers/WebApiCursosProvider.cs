using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppControlCursos.Interfaces;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Providers
{
	public class WebApiCursosProvider : ICoursesProvider
	{
		private readonly IHttpClientFactory httpClientFactory;

		public WebApiCursosProvider(IHttpClientFactory	httpClientFactory)
        {
			this.httpClientFactory = httpClientFactory;
		}

        public async Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
		{
			var client = httpClientFactory.CreateClient("coursesService");

			var body = new StringContent(JsonSerializer.Serialize(course), System.Text.Encoding.UTF8, "application/json");

			var response = await client.PostAsync("api/cursos", body);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				var result = JsonSerializer.Deserialize<int?>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return (true, result);
			}

			return (false, null);
		}

        public async Task<Course> EliminarAsync(int id)
        {            
                var client = httpClientFactory.CreateClient("coursesService");
                var response = await client.DeleteAsync($"api/cursos/{id}");

                if (response.IsSuccessStatusCode)
                {
					return null;
				}
				
				return null;
        }

        public async Task<ICollection<Course>> GetAllAsync()
		{
			var client = httpClientFactory.CreateClient("coursesService");

			var response = await client.GetAsync("api/cursos");

            if (response.IsSuccessStatusCode)
            {
				var content = await response.Content.ReadAsStringAsync(); 
				//byte[] byteArray = Encoding.UTF8.GetBytes(content); 
				var results = JsonSerializer.Deserialize<ICollection<Course>>(content, new JsonSerializerOptions() 
				{ PropertyNameCaseInsensitive = true });
				return results;
            }
			return null;
        }

		public async Task<Course> GetAsync(int id)
		{
			var client = httpClientFactory.CreateClient("coursesService");
			var response = await client.GetAsync($"api/cursos/{id}");

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				var result = JsonSerializer.Deserialize<Course>(content, new JsonSerializerOptions() 
				{ PropertyNameCaseInsensitive = true });

				return result;
			}

			return null;
		}

		public async Task<ICollection<Course>> SearchAsync(string search)
		{
			var client = httpClientFactory.CreateClient("coursesService");

			var response = await client.GetAsync($"api/cursos/search/{search}");

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				//byte[] byteArray = Encoding.UTF8.GetBytes(content); 
				var result = JsonSerializer.Deserialize<ICollection<Course>>(content, new JsonSerializerOptions()
				{ PropertyNameCaseInsensitive = true });
				return result;
			}
			return null;

		}

		public async Task<bool> UpdateAsync(int id, Course course)
		{
			var client = httpClientFactory.CreateClient("coursesService");

			var body = new StringContent(JsonSerializer.Serialize(course),
								System.Text.Encoding.UTF8,
								"application/json");

			var response = await client.PutAsync($"api/cursos/{id}", body);

			if (response.IsSuccessStatusCode)
			{
				return true;
			}
			return false;
		}
	}
}
