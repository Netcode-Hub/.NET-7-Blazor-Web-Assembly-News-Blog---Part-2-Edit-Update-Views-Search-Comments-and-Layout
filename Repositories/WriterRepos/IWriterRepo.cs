using DemoBlogForYoutube.Shared.Models;

namespace DemoBlogForYoutube.Server.Repositories.WriterRepos
{
    public interface IWriterRepo
    {
        Task<List<Writer>> Get();
    }
}
