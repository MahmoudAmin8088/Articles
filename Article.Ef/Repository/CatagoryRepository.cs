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
    public class CatagoryRepository:BaseRepository<Catagory>,ICatagoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CatagoryRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
