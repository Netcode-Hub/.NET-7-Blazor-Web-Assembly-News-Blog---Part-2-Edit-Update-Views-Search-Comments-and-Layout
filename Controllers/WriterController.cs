using DemoBlogForYoutube.Server.Repositories.CategoryRepos;
using DemoBlogForYoutube.Server.Repositories.WriterRepos;
using DemoBlogForYoutube.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoBlogForYoutube.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IWriterRepo writerRepo;

        public WriterController(IWriterRepo writerRepo )
        {
            this.writerRepo = writerRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Writer>>> Get()
        {
            return Ok(await writerRepo.Get());
        }
    }
}
