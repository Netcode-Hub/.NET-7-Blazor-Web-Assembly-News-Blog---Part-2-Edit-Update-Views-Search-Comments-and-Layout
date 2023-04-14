using DemoBlogForYoutube.Shared;
using DemoBlogForYoutube.Shared.Models;
using System.Net.Http.Json;
using System.Reflection;

namespace DemoBlogForYoutube.Client.Services.NewsServices
{
    public class NewsService : INewsService
    {
        private readonly HttpClient httpClient;
        public NewsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Status> AddOrUpdateNews(News model)
        {
            var result = await httpClient.PostAsJsonAsync("api/news/add", model);
            var response = await result.Content.ReadFromJsonAsync<Status>();
            return response!;
        }

        public async Task<List<News>> Get()
        {
            var result = await httpClient.GetAsync("api/news");
            var response = await result.Content.ReadFromJsonAsync<List<News>>();
            return response!;
        }

        public async Task<News> GetNewByUrl(string url)
        {
            var result = await httpClient.GetAsync($"api/news/latest/{url}");
            var response = await result.Content.ReadFromJsonAsync<News>();
            return response!;
        }

        public async Task<News> GetNews(int id)
        {
            var result = await httpClient.GetAsync($"api/news/{id}");
            var response = await result.Content.ReadFromJsonAsync<News>();
            return response!;

        }

        public async Task<List<News>> Top()
        {
            var result = await httpClient.GetAsync("api/news/top");
            var response = await result.Content.ReadFromJsonAsync<List<News>>();
            return response!;
        }
        public async Task<List<News>> GetNewsByCategory(string categoryName)
        {
            var result = await httpClient.GetAsync($"api/news/category/{categoryName}");
            var response = await result.Content.ReadFromJsonAsync<List<News>>();
            return response!;
        }
        public async Task<List<News>> SearchNews(string searchText)
        {
            var result = await httpClient.GetAsync($"api/news/search/{searchText}");
            var response = await result.Content.ReadFromJsonAsync<List<News>>();
            return response!;
        }

        public async Task<Status> SendComment(Comment model)
        {
            var result = await httpClient.PostAsJsonAsync("api/news/add/comment", model);
            var response = await result.Content.ReadFromJsonAsync<Status>();
            return response!;
        }

        public async Task<Status> DeleteNews(int id)
        {
            var result = await httpClient.DeleteAsync($"api/news/{id}");
            var response = await result.Content.ReadFromJsonAsync<Status>();
            return response!;
        }


    }
    
}
