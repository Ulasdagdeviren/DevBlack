using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevBlack.Northwind.Business.Abstract;
using DevBlack.Northwind.Entity.Concrete;
using DevBlack.Northwind.MvcWebUI.Models;

namespace DevBlack.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        { 
            var model=new ProductListViewModel
            {
                Products = _productService.Get()
            };

            return View(model);

        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "Computer",
                QuantityPerUnit = "2",
                UnitPrice = 2
            });
            return "Added";
        }
    }
}