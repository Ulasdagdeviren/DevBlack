using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Northwind.Entity.Concrete;

namespace DevBlack.Northwind.DataAcsess.Concrete.EntityFramework.Mapping
{
   public class ProductMaps:EntityTypeConfiguration<Product>
    {
        public ProductMaps()
        {
            ToTable(@"Products", @"dbo");
            HasKey(x => x.ProdcutId);
            Property(x => x.ProdcutId).HasColumnName("ProductId");
            Property(x => x.CategoryId).HasColumnName("CategoryId");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");
        }
    }
}
