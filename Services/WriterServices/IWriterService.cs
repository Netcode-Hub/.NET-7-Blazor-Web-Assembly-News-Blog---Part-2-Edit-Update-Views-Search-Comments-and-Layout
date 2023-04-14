using DemoBlogForYoutube.Shared.Models;

namespace DemoBlogForYoutube.Client.Services.WriterServices
{
    public interface IWriterService 
    {
        Task<List<Writer>> Get();
    }
}
