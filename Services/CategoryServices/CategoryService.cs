using DemoBlogForYoutube.Shared.Models;
using System.Net.Http.Json;

namespace DemoBlogForYoutube.Client.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient httpClient;

        public CategoryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Category>> Get()
        {
            var result = await httpClient.GetAsync("api/category");
            var response = await result.Content.ReadFromJsonAsync<List<Category>>();
            return response!;
        }
    }
}
