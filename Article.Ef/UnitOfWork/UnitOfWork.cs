using Article.core.IRepository;
using Article.core.IUnitOfWork;
using Article.core.Model;
using Article.Ef.Data;
using Article.Ef.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Ef.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

       

        public IArticleRepository Articles { get; private set; }

        public ICommentRepository Comments { get; private set; }

        public ICatagoryRepository Catagorys { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Articles = new ArticleRepository(_context);
            Comments = new CommentRepository(_context);
            Catagorys = new CatagoryRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
          _context.Dispose();   
        }
    }
}
