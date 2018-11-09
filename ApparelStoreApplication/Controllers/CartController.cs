using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreApplication.Models;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static ApparelStoreApplication.Components.FiltersApp;

namespace ApparelStoreApplication.Controllers
{
    public class CartController : Controller
    {
        SearchService service;
        public CartController()
        {
            service = new SearchService();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost][HttpGet]
        public IActionResult AddToCart(ProductViewModel Model)
        {
            service.context = HttpContext;
            service.AddToCart(Model);
            string json = HttpContext.Session.GetString("CatSubCat");
            SubCategory subcategory = JsonConvert.DeserializeObject<SubCategory>(json);
            return RedirectToAction("GetProducts", "Search",subcategory);
        }
        [HttpGet]
        public IActionResult ViewCart()
        {

            service.context = HttpContext;
            List<ProductViewModelCart> result = service.ProductCart();
            ViewData["products"] = result;
            return View(result);
        }

        [HttpPost]

        public IActionResult PlaceOrder(ProductViewModelCart[] p)
        {

            List<ProcessOrder> productList = new List<ProcessOrder>();
            int Totalsum=0;
            foreach (var i in p)
            {
                ProcessOrder obj = new ProcessOrder();
                obj.ProductId = i.ProductId;
                obj.Price = i.Price;
                obj.sum = (int)(i.Price * i.Quantity);
                obj.Quantity = i.Quantity;
                obj.Title = i.Title;
                //if(productList.Find(obj))
                productList.Add(obj);
                Totalsum += obj.sum;
                ViewData["Totalsum"] = Totalsum;

            }
            ViewData["products"] = productList;
            return View();
        }






    }
 }


