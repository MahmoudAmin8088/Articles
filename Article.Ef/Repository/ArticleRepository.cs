using Article.core.IRepository;
using Article.core.Model;
using Article.Ef.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Ef.Repository
{
    public class ArticleRepository : BaseRepository<Articles>, IArticleRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleRepository(ApplicationDbContext context):base(context)    
        {
            _context = context;
        }
    
        public ICollection<Articles> GetArticlesByCatagory(string catagoryId)
        {
            return _context.Articles.Include(a => a.Catigory).Where(c => c.CatigoryId == catagoryId).OrderBy(a=>a.ArticleTime).ToList();
        }

        public ICollection<Articles> GetUsersArticles(string userId)
        {
            return _context.Articles.Include(a => a.User).Where(a => a.UserId == userId).ToList();
        }
    }
}
