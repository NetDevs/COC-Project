using System;
using System.Collections.Generic;

namespace ApparelStoreWebService.Models.DB
{
    public partial class Orders
    {
        public Orders()
        {
            Payment = new HashSet<Payment>();
            ProductOrderDetails = new HashSet<ProductOrderDetails>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Payment> Payment { get; set; }
        public ICollection<ProductOrderDetails> ProductOrderDetails { get; set; }
    }
}
