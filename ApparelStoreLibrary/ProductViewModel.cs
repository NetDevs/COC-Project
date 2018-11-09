using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApparelStoreApplication.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string ProductImage { get; set; } 
       
        public override bool Equals(object obj)
        {
            return ((ProductViewModel)obj).ProductId == ProductId;
        }
        public override int GetHashCode()
        {
            return ProductId.GetHashCode();
        }
    }
    public class ProductViewModelCart : ProductViewModel
    {
        public int Quantity { get; set; }
        public override bool Equals(object obj)
        {
            return ((ProductViewModelCart)obj).ProductId == ProductId;
        }
        public override int GetHashCode()
        {
            return ProductId.GetHashCode();
        }
    }
    public class ProcessOrder : ProductViewModelCart
    {
        public int sum { get; set; }
    }
}