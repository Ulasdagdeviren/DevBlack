using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.DataAcsess.EntityFramework;
using DevBlack.Northwind.DataAcsess.Abstract;
using DevBlack.Northwind.Entity.ComplexTypes;
using DevBlack.Northwind.Entity.Concrete;

namespace DevBlack.Northwind.DataAcsess.Concrete.EntityFramework
{
   public class EfProductDal:EfRepositoryBase<Product,NorthwindContex>,IProductDal
   {
       public List<ProductDetail> Get()
       {
           using (NorthwindContex contex=new NorthwindContex())
           {
               var result = from p in contex.Products
                   join c in contex.Categories on p.CategoryId equals c.CategoryId
                   select new ProductDetail()
                   {
                       ProductName = p.ProductName,
                       CategoryName = c.CategoryName,
                       ProductId = p.ProdcutId
                   };
               return result.ToList();
           }
       }
   }
}
