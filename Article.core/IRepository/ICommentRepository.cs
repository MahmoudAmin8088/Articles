using Article.core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.IRepository
{
    public interface ICommentRepository:IBaseRepository<Comment>
    {
        ICollection<Comment> GetArticleComments(string articleId);
    }
}
