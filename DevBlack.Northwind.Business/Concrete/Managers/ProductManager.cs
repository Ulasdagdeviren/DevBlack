using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.Aspect.PostSharp.CacheAspect;
using DevBlack.Core.Aspect.PostSharp.LogAspect;
using DevBlack.Core.Aspect.PostSharp.ValidationAspect;
using DevBlack.Core.CrossCutingConcerns.Cache.Microsoft;
using DevBlack.Core.CrossCutingConcerns.Logging.Log4Net.Loggers;
using DevBlack.Northwind.Business.Abstract;
using DevBlack.Northwind.Business.ValidationRules.FluentValidation;
using DevBlack.Northwind.DataAcsess.Abstract;
using DevBlack.Northwind.Entity.Concrete;

namespace DevBlack.Northwind.Business.Concrete.Managers
{
    [LogAspect(typeof(FileLogger))]
    public class ProductManager:IProductService
   {
       private IProductDal _product;

       public ProductManager(IProductDal product)
       {
           _product = product;
       }
        [CacheAspect(typeof(MemoryCacheManager),60)]
        [FluentValidationAspect(typeof(ProductValidator))]
        [LogAspect(typeof(DatabaseLogger))]
       
       public List<Product> Get()
       {
           return _product.GetList();
       }

        public Product GetById(int id)
        {
            return _product.Get(x => x.ProdcutId == id);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _product.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _product.Update(product);
        }

        public void TransactionalOperation(Product product, Product product2)
        {
            _product.Add(product);

            _product.Update(product2);
        }
    }
}
