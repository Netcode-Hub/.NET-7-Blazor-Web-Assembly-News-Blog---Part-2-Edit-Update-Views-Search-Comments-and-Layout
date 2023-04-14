using DemoBlogForYoutube.Server.Data;
using DemoBlogForYoutube.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoBlogForYoutube.Server.Repositories.CategoryRepos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Category>> Get()
        {
            var results = await appDbContext.Categories.ToListAsync();
            return results!;
        }
    }
}
