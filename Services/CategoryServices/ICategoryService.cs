using DemoBlogForYoutube.Shared.Models;

namespace DemoBlogForYoutube.Client.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<Category>> Get();
    }
}
