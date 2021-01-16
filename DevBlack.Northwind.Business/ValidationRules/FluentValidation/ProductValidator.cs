using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevBlack.Northwind.Entity.Concrete;
using FluentValidation;

namespace DevBlack.Northwind.Business.ValidationRules.FluentValidation
{
   public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.ProductName).Length(2,20);
            RuleFor(x => x.QuantityPerUnit).NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThan(0);
            RuleFor(x => x.UnitPrice).GreaterThan(20).When(p => p.CategoryId == 1);
        }
    }
}
