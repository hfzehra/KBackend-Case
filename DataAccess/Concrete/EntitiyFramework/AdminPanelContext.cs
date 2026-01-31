using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class AdminPanelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(@"Server =(localdb)\ZEHRA; Database=KayraBackend1; Trusted_Connection=true");
            //.optionsBuilder.UseInMemoryDatabase("ProductManager");
        }

        public DbSet<Product> Products { get; set; }
    }
}
