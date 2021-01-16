using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Northwind.Business.ValidationRules.FluentValidation;
using DevBlack.Northwind.Entity.Concrete;
using FluentValidation;
using Ninject.Modules;

namespace DevBlack.Northwind.Business.DependencyResolves.Ninject
{
   public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>();
        }
    }
}
