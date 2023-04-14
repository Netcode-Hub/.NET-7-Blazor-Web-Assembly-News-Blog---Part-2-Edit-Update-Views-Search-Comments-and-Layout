using DemoBlogForYoutube.Server.Data;
using DemoBlogForYoutube.Shared;
using DemoBlogForYoutube.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoBlogForYoutube.Server.Repositories.NewsRepos
{
    public class NewsRepo : INewsRepo
    {
        private readonly AppDbContext appDbContext;
        public NewsRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Status> AddOrUpdateNews(News model)
        {
            var status = new Status();
            if(model != null)
            {
                if(model.Id > 0)
                {
                    //updating old blog
                    var result = await GetNews(model.Id);
                    if(result != null)
                    {
                        //populate the news and update
                        result.CategoryId = model.CategoryId;
                        result.WriterId = model.WriterId;
                        result.Title = model.Title;
                        result.Publication = model.Publication;
                        result.IsPublic = model.IsPublic;
                        result.TitleImage = model.TitleImage;
                        result.Source = model.Source;
                        result.Url = model.Title!.ToLower().Replace(" ", "-").Replace("?", "-");
                        await appDbContext.SaveChangesAsync();
                        status.Message = "News successfully updated!";
                        status.Success = true;
                        return status;
                    }
                    status.Message = "News not found";
                    status.Success = false;
                    return status;

                }
                else
                {
                    //adding new blog
                    var checkEx = await appDbContext.News
                    .Where(n => n.Title!.ToLower().Replace(" ", "-").Replace("?", "-")
                    .Equals(model.Title!.ToLower().Replace(" ", "-").Replace("?", "-")))
                    .FirstOrDefaultAsync();

                    if (checkEx != null)
                    {
                        status.Success = false;
                        status.Message = "News already added";
                        return status;
                    }

                    appDbContext.News.Add(model);
                    model.Url = model.Title!.ToLower().Replace(" ", "-").Replace("?", "-");
                    await appDbContext.SaveChangesAsync();
                    status.Success = true;
                    status.Message = "News added successfully";
                    return status;
                }
            }
            status.Success = false;
            status.Message = "News object is empty";
            return status;
        }

        public async Task<List<News>> Get()
        {
            var result = await appDbContext.News.Include(c=> c.Comments).ToListAsync();
            return result!;
        }

        public async Task<News> GetNews(int id)
        {
            var result = await appDbContext.News.Where(n => n.Id == id).Include(c => c.Comments).Include(c=> c.Category).Include(w=> w.Writer).FirstOrDefaultAsync();
            if (result != null)
                return result;
            return null!;
        }

        public async Task<List<News>> Top()
        {
            var results = await appDbContext.News.OrderByDescending(d => d.DateCreated).Skip(0).Take(8).ToListAsync();
            return results!;
        }

        public async Task<News> GetNewByUrl(string url)
        {
            var result = await appDbContext.News.Where(n => n.Url == url).Include(c => c.Comments).FirstOrDefaultAsync();
            if (result != null)
                return result;
            return null!;
        }

        public async Task<List<News>> GetNewsByCategory(string categoryName)
        {
            var results = await appDbContext.News.Where(n => n.Category!.Name!.ToLower().Equals(categoryName.ToLower())).Include(c => c.Comments).ToListAsync();
            return results!;
        }

        public async Task<List<News>> SearchNews(string searchText)
        {
            var results = await appDbContext.News.Where(n => n.Title!.ToLower().Contains(searchText.ToLower())).Include(c => c.Comments).ToListAsync();
            return results!;
        }

        public async Task<Status> SendComment(Comment model)
        {
            var status = new Status();
            if (model != null)
            {
                    //adding new blog
                    var checkEx = await appDbContext.Comments
                    .Where(n => n.Message!.ToLower()
                    .Equals(model.Message!.ToLower()))
                    .FirstOrDefaultAsync();

                    if (checkEx != null)
                    {
                        status.Success = false;
                        status.Message = "Comment already created";
                        return status;
                    }

                    appDbContext.Comments.Add(model);
                    await appDbContext.SaveChangesAsync();
                    status.Success = true;
                    status.Message = "Comment added successfully";
                    return status;
                
            }
            status.Success = false;
            status.Message = "Comment object is empty";
            return status;
        }


        public async Task<Status> DeleteNews(int id)
        {
            var status = new Status();
           var result = await appDbContext.News.Where(n=> n.Id == id).FirstOrDefaultAsync();
            if(result != null){
                appDbContext.News.Remove(result);
                await appDbContext.SaveChangesAsync();

                status.Success = true;
                status.Message = "News deleted successfully!";
                return status;
            }
            status.Success = false;
            status.Message = "News cannot be found!";
            return status;

        }
    }
}
