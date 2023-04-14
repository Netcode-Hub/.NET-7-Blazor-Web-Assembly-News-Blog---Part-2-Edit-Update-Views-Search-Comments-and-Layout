using DemoBlogForYoutube.Shared;
using DemoBlogForYoutube.Shared.Models;

namespace DemoBlogForYoutube.Server.Repositories.NewsRepos
{
    public interface INewsRepo
    {
        Task<Status> AddOrUpdateNews(News model);
        Task<List<News>> Get();
        Task<News> GetNews(int id);
        Task<List<News>> Top();
        Task<News> GetNewByUrl(string url);
        Task<List<News>> GetNewsByCategory(string categoryName);
        Task<List<News>> SearchNews(string searchText);
        Task<Status> SendComment(Comment model);
        Task<Status> DeleteNews(int id);





    }
}
