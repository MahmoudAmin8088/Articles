using Article.core.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Article.core.Model;

namespace Article.Ef.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Catagory> Catagories { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

    }
}
