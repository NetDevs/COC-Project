 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreApplication.Models;
using ApparelStoreWebService.Models;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static ApparelStoreApplication.Components.FiltersApp;

namespace ApparelStoreApplication.Controllers
{
    public class CartController : Controller
    {
        ApparelStoreApplication.Models.SearchService service;
        public CartController()
        {
            service = new ApparelStoreApplication.Models.SearchService();
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
        [HttpPost]
        [HttpGet]
        public IActionResult RemoveFromCart(int id)
        {
            service.context = HttpContext;
            service.RemoveFromCart(id);
            return RedirectToAction("ViewCart", "Cart");
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
            HttpContext.Session.Remove("Cart");
            string json = JsonConvert.SerializeObject(p);
            HttpContext.Session.SetString("Cart", json);
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

        [HttpPost]
        public IActionResult Payment(string optradio)
        {
            InvoiceDetails data;
            if (optradio != null)
            {
                ApparelStoreApplication.Models.BookingService svc = new ApparelStoreApplication.Models.BookingService();
                svc.context = HttpContext;
                FinalOrder details=svc.PlaceOrder(optradio,out data);

                ViewData["details"] = details;
                ViewData["invoice"] = data;
                return View("Invoice");
            }
            return View();
        }
       [HttpPost]
       [HttpGet]
       public IActionResult Details()
        {
            
            return View();


        }

    }
 }


