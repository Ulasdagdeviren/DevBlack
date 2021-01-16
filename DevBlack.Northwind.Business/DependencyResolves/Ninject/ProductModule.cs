using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Core.DataAcsess;
using DevBlack.Core.DataAcsess.EntityFramework;
using DevBlack.Northwind.Business.Abstract;
using DevBlack.Northwind.Business.Concrete.Managers;
using DevBlack.Northwind.DataAcsess.Abstract;
using DevBlack.Northwind.DataAcsess.Concrete;
using DevBlack.Northwind.DataAcsess.Concrete.EntityFramework;
using Ninject.Modules;

namespace DevBlack.Northwind.Business.DependencyResolves.Ninject
{
   public class ProductModule:NinjectModule
   {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();
            Bind<DbContext>().To<NorthwindContex>();
            Bind(typeof(IQeryableRepository<>)).To(typeof(EfQeryableRepository<>));
        }
    }
}
