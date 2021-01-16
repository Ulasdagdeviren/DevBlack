using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlack.Northwind.Entity.ComplexTypes
{
   public class ProductDetail
    {
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string CategoryName { get; set; }
    }
}
