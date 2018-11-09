using System;
using System.Collections.Generic;

namespace ApparelStoreWebService.Models.DB
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetails>();
        }

        public int PurOrdId { get; set; }
        public DateTime? PurOrdDate { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }

        public ICollection<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
    }
}
