  using ApparelStoreWebService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApparelStoreWebService.Models
{
    public class SearchService
    {
        ApparelStoreContext context;
        public SearchService()
        {
            context = new ApparelStoreContext();
        }
        public List<Category> GetCategories()
        {
           
            var result = (from c in context.Category
                          select c).ToList();
            return result;
        }
        
        
        public List<SubCategory> GetSubCategories(int id)
        {
            var result = (from c in context.SubCategory
                          where c.CategoryId == id
                          select c).ToList();
            return result;

        }
      
        public List<Product> GetProducts(SubCategory search)
        {
            var result = (from c in context.Product
                          where c.CategoryId == search.CategoryId && c.SubCategoryId == search.SubCategoryId
                          select c).ToList();
            

            return result;
        }
        //public List<Product> ProductViewModel(Product P)
        //{
        //    var result = (from c in context.Product select new ProductViewModel()
        //                  {


        //                  });
        //    return result;
        //}

    }
}
