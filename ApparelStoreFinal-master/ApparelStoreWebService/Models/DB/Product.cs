using System;
using System.Collections.Generic;

namespace ApparelStoreWebService.Models.DB
{
    public partial class Product
    {
        public Product()
        {
            ProductOrderDetails = new HashSet<ProductOrderDetails>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
        }

        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? Quantity { get; set; }
        public int? ReorderLevel { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }

        public Category Category { get; set; }
        public ICollection<ProductOrderDetails> ProductOrderDetails { get; set; }
        public ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    }
}
