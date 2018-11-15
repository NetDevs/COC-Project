using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreApplication.Models;
using ApparelStoreWebService.Models;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApparelStoreWebService.Controllers
{
    [Route("Booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        BookingService service;
        ApparelStoreContext context;
        public BookingController(ApparelStoreContext context)
        {
            this.context = context;
            service = new BookingService(this.context);
        }
        [HttpPost]
        [Route("Invoice")]
        public IActionResult Invoice(FinalOrder finalOrder)
        {
            InvoiceDetails invoicedetails = service.Invoice(finalOrder);

            return Ok(invoicedetails);

        }
    }
}