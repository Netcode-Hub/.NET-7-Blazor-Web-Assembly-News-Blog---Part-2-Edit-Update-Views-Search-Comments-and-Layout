using DemoBlogForYoutube.Shared.Models;
using System.Net.Http.Json;

namespace DemoBlogForYoutube.Client.Services.WriterServices
{
    public class WriterService : IWriterService
    {
        private readonly HttpClient httpClient;

        public WriterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Writer>> Get()
        {
            var result = await httpClient.GetAsync("api/Writer");
            var response = await result.Content.ReadFromJsonAsync<List<Writer>>();
            return response!;
        }
    }
}
