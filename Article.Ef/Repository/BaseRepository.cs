using Article.core.IRepository;
using Article.core.Model;
using Article.Ef.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Ef.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public ICollection<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
