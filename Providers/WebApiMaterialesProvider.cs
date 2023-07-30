using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebAppControlCursos.Interfaces;
using WebAppControlCursos.Models;

namespace WebAppControlCursos.Providers
{
	public class WebApiMaterialesProvider : IMaterialsProvider
	{
		private readonly IHttpClientFactory httpClientFactory;

		public WebApiMaterialesProvider(IHttpClientFactory httpClientFactory)
		{
			this.httpClientFactory = httpClientFactory;
		}
		public async Task<ICollection<Material>> GetAllMaterialsAsync(int id)
		{
			var client = httpClientFactory.CreateClient("coursesService");

			var response = await client.GetAsync($"api/materiales/{id}");

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				//byte[] byteArray = Encoding.UTF8.GetBytes(content); 
				var results = JsonSerializer.Deserialize<ICollection<Material>>(content, new JsonSerializerOptions()
				{ PropertyNameCaseInsensitive = true });
				return results;
			}
			return null;
		}
	}
}
