using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.core.IRepository
{
    public interface IBaseRepository<T>where T : class
    {
        ICollection<T> GetAll();
        T GetById(string id);
        T Create(T entity); 
        T Update(T entity);
        T Delete(T entity);

    }
}
