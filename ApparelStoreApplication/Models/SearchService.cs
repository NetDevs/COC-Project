using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApparelStoreApplication.Models
{
    public class SearchService
    {
        HttpClient client;
        public HttpContext context;
        public SearchService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50821/");
        }

        public List<Category> GetCategories()
        {
            HttpResponseMessage response = client.GetAsync("/SearchService/Categories").Result;
            string json=response.Content.ReadAsStringAsync().Result;
            List<Category>  categories=JsonConvert.DeserializeObject<List<Category>>(json);
            return categories;
            
        }
        
        public List<Product> GetProducts(SubCategory S)
        {
            
            string json = JsonConvert.SerializeObject(S);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/SearchService/GetProducts",content).Result;
            json = response.Content.ReadAsStringAsync().Result;
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
            return products;
        }
        public SubCategory CategoryCheck(HttpContext context,SubCategory S)
        {
            return null;
        }
        public void AddToCart(ProductViewModel model)
        {
            List<ProductViewModel> serializedObjects;
            string json = "";
            byte[] ary;

            // json = context.Session.GetString("CatSubCat");
            // SubCategory subcategory = JsonConvert.DeserializeObject<SubCategory>(json);
            bool isavailable = context.Session.TryGetValue("Cart", out ary);
            if (isavailable == false)
            {
                serializedObjects = new List<ProductViewModel>();
                serializedObjects.Add(model);
                serializedObjects = serializedObjects.Distinct().ToList();
                json = JsonConvert.SerializeObject(serializedObjects);
                context.Session.SetString("Cart", json);
            }
            else
            {
                json = context.Session.GetString("Cart");
                serializedObjects = JsonConvert.DeserializeObject<List<ProductViewModel>>(json);
                serializedObjects.Add(model);
                serializedObjects = serializedObjects.Distinct().ToList();
                json = JsonConvert.SerializeObject(serializedObjects);
                context.Session.SetString("Cart", json);
            }

        }
        public List<ProductViewModelCart> ProductCart()
        {
            // List<ProductViewModelCart> serializedObjects;
            string json = "";
            byte[] ary;
            bool isavailable = context.Session.TryGetValue("Cart", out ary);
            json = context.Session.GetString("Cart");
            //serializedObjects = JsonConvert.DeserializeObject<List<ProductViewModelCart>>(json);
            List<ProductViewModelCart> list = JsonConvert.DeserializeObject<List<ProductViewModelCart>>(json);

            List<ProductViewModelCart> result = (from c in list
                                                 select new ProductViewModelCart()
                                                 {
                                                     CategoryId = c.CategoryId,
                                                     Price = c.Price,
                                                     ProductId = c.ProductId,
                                                     Quantity = c.Quantity,
                                                     SubCategoryId = c.SubCategoryId,
                                                     Title = c.Title
                                                 }).ToList();

            return result.Distinct().ToList();
        }
    }
}
