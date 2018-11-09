using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreWebService.Components;
using ApparelStoreWebService.Models;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApparelStoreWebService.Controllers
{
    [Route("SearchService")]
    [ApiController]
    public class SearchServiceController : ControllerBase
    {
        SearchService service;
        public SearchServiceController(ApparelStoreContext context)
        {
            service = new SearchService();
        }

        [ServiceErrorFilter]
        [HttpGet]
        [Route("Categories")]
        public List<Category> GetCategories()
        {
            return service.GetCategories();

        }
        [HttpGet]
        [Route("SubCategories/{id}")]
        public List<SubCategory> GetSubCategories(int id)
        {
            return service.GetSubCategories(id);

        }
        [Route("GetProducts")]
        [HttpPost]
        public List<Product> GetProducts(SubCategory subcategory)
        {
            return service.GetProducts(subcategory);
        }

       
    }
}