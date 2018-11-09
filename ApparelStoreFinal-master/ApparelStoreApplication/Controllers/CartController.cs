using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreApplication.Models;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    }
}