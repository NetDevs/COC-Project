using System;
using System.Collections.Generic;

namespace ApparelStoreWebService.Models.DB
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public long? Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
