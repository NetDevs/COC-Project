using System;
using System.Collections.Generic;

namespace ApparelStoreWebService.Models.DB
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
            SubCategory = new HashSet<SubCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Product { get; set; }
        public ICollection<SubCategory> SubCategory { get; set; }
    }
}
