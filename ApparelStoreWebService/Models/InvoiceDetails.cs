using ApparelStoreWebService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApparelStoreWebService.Models
{
    public class InvoiceDetails
    {
       public Customer customer { get; set; }
        public int InvoiceNo { get; set; }
    }
}
