using System;
using System.Collections.Generic;

namespace ApparelStoreWebService.Models.DB
{
    public partial class ProductOrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public Orders Order { get; set; }
        public Product Product { get; set; }
    }
}
