using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Northwind.DataAcsess.Concrete.EntityFramework.Mapping;
using DevBlack.Northwind.Entity.Concrete;

namespace DevBlack.Northwind.DataAcsess.Concrete
{
   public class NorthwindContex:DbContext
    {
        public NorthwindContex()
        {
            Database.SetInitializer<NorthwindContex>(null);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMaps());
            modelBuilder.Configurations.Add(new CategoryMap());
        }
    }
}
