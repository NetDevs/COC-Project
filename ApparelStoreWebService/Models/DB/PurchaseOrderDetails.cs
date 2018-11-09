using System;
using System.Collections.Generic;

namespace ApparelStoreWebService.Models.DB
{
    public partial class PurchaseOrderDetails
    {
        public int PurOrdId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public Product Product { get; set; }
        public PurchaseOrder PurOrd { get; set; }
    }
}
