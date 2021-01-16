using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Northwind.Entity.Concrete;

namespace DevBlack.Northwind.Business.Abstract
{
  public interface IProductService
  {
      List<Product> Get();
      Product GetById(int id);
      Product Add(Product product);
      Product Update(Product product);
      void TransactionalOperation(Product product, Product product2);

    }
}
