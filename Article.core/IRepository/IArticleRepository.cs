using Article.core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.IRepository
{
    public interface IArticleRepository:IBaseRepository<Articles>
    {
        ICollection<Articles> GetUsersArticles(string userId);
        ICollection<Articles> GetArticlesByCatagory(string catagoryId);
    }
}
