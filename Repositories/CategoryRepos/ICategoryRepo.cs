using DemoBlogForYoutube.Shared.Models;

namespace DemoBlogForYoutube.Server.Repositories.CategoryRepos
{
    public interface ICategoryRepo
    {
        Task<List<Category>> Get();
    }
}
