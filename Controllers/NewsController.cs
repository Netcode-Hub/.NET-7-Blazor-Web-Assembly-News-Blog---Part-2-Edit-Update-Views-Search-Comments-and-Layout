using DemoBlogForYoutube.Server.Repositories.NewsRepos;
using DemoBlogForYoutube.Shared;
using DemoBlogForYoutube.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoBlogForYoutube.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepo newsRepo;
        public NewsController(INewsRepo newsRepo)
        {
            this.newsRepo = newsRepo;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Status>> AddOrUpdateNews(News model)
        {
            if (model == null)
                return BadRequest("News Model is empty");
            return Ok(await newsRepo.AddOrUpdateNews(model));
        }

        [HttpGet]
        public async Task<ActionResult<List<News>>> Get()
        {
            return Ok(await newsRepo.Get());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            if (id > 0)
            {
                var result = await newsRepo.GetNews(id);
                if (result == null)
                    return NotFound("News not found");
                return Ok(result);
            }
            return BadRequest("News id cannot be zero");
        }

        [HttpGet("top")]
        public async Task<ActionResult<List<News>>> Top()
        {
            return Ok(await newsRepo.Top());
        }

        [HttpGet("latest/{url}")]
        public async Task<ActionResult<News>> GetNewByUrl(string url)
        {
            if (url != null)
            {
                var result = await newsRepo.GetNewByUrl(url);
                if (result == null)
                    return NotFound("News not found");
                return Ok(result);
            }
            return BadRequest("News id cannot be zero");
        }

        [HttpGet("category/{categoryName}")]
        public async Task<ActionResult<List<News>>> GetNewsByCategory(string categoryName)
        {
            return Ok(await newsRepo.GetNewsByCategory(categoryName));
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<News>>> SearchNews(string searchText)
        {
            return Ok(await newsRepo.SearchNews(searchText));
        }

        [HttpPost("add/comment")]
        public async Task<ActionResult<Status>> SendComment(Comment model)
        {
            if (model == null)
                return BadRequest("Comment Model is empty");
            return Ok(await newsRepo.SendComment(model));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Status>> DeleteNews(int id)
        {
            if (id > 0)
                return Ok(await newsRepo.DeleteNews(id));
            return BadRequest("News not specified");
            
        }
        
    }
}
