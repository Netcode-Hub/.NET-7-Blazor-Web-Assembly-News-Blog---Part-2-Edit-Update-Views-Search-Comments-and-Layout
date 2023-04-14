using DemoBlogForYoutube.Server.Data;
using DemoBlogForYoutube.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoBlogForYoutube.Server.Repositories.WriterRepos
{
    public class WriterRepo : IWriterRepo
    {
        private readonly AppDbContext appDbContext;
        public WriterRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Writer>> Get()
        {
            var results = await appDbContext.Writers.ToListAsync();
            return results!;
        }
    }
}
