using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevBlack.Northwind.Entity.Concrete;

namespace DevBlack.Northwind.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
    }
}