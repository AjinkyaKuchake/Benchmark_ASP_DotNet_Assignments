using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutViewsExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            var products = new[] { 
                new { ProductId=1, ProductName="Fridge", Cost = 20000 },
                new { ProductId=2, ProductName="AC", Cost = 18000 },
                new { ProductId=3, ProductName="TV", Cost = 30000 }};

            if (id == null)
            {
                return Content("Please pass any product name");
            }

            string prodName = "";

            foreach (var item in products)
            {
                if (item.ProductId == id)
                {
                    prodName = item.ProductName;
                }
            }

            return Content(prodName);
        }


        public ActionResult GetProductId(string pname)
        {
            var products = new[] { new { ProductId=1,ProductName="Remote",Cost=1000},
                                   new { ProductId=2,ProductName="Stereo",Cost=2000},
                                   new { ProductId=3,ProductName="Radio", Cost=3000}};
            if (pname == null)
            {
                return Content("Please pass any product name");
            }
            else
            {
                int prodId = 0;
                foreach (var item in products)
                {
                    if (item.ProductName == pname)
                    {
                        prodId = item.ProductId;
                    }
                }

                return Content("The required product Id is: " + prodId.ToString());
            }
        }
    }
}