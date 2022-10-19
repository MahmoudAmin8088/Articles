using Article.core.IRepository;
using Article.core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.IUnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IArticleRepository Articles { get; }
        ICommentRepository Comments { get; }
        ICatagoryRepository Catagorys { get; }

        int Complete();


    }
}
