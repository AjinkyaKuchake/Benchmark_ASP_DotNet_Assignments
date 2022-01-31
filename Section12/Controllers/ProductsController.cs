using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelExample.Models;//Import the Model created

namespace ModelExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product(){ProductId=101,ProductName="AC",Rate = 45000 },
                new Product(){ProductId=102,ProductName="Mobile",Rate = 38000 },
                new Product(){ProductId=103,ProductName="Bike",Rate = 94000 }
            };

            //ViewBag.products = products;
            return View(products);
        }

        public ActionResult Details(int? id)
        {
            List<Product> products = new List<Product>()
            {
                new Product(){ProductId=101,ProductName="AC",Rate = 45000 },
                new Product(){ProductId=102,ProductName="Mobile",Rate = 38000 },
                new Product(){ProductId=103,ProductName="Bike",Rate = 94000 }
            };

            Product matchingProduct = null;

            foreach (var item in products)
            {
                if (item.ProductId == id)
                {
                    matchingProduct = item;
                }
            }

            //ViewBag.MatchingProduct = matchingProduct; //Use when not usinga strongly typed View.
            //return View();

            //Use when you want a strogly typed View. Pass the Model Object
            return View(matchingProduct);
            //You can also explicitly specify the View Name;
            //return View("Details",matchingProduct);
        }

        //This will be called for all other Http requests
        public ActionResult Create()
        {
            return View();
        }

        //This will be called particularly for POST requests
        [HttpPost]
        public ActionResult Create([Bind(Include="ProductId,ProductName")] Product p)
        {
            return View();
        }
    }

  
}