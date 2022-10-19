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
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public ICollection<Comment> GetArticleComments(string articleId)
        {
            return _context.Comments.Include(c => c.Article)
                .Where(c => c.ArticleId == articleId).OrderBy(c => c.CommentTime).ToList();
        }

        
    }
}
