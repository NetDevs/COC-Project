using System;
using System.Collections.Generic;

namespace ApparelStoreWebService.Models.DB
{
    public partial class Payment
    {
        public int? OrderId { get; set; }
        public string Method { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int InvoiceNo { get; set; }

        public Orders Order { get; set; }
    }
}
