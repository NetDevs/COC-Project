using ApparelStoreWebService.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApparelStoreApplication.Models
{
    public class BookingService
    {
        public HttpContext context;
        HttpClient client;
        public BookingService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50821/");
        }
       
        public FinalOrder PlaceOrder(string paymentmode,out InvoiceDetails InvoiceNo)
        {
            var customerId = context.Session.GetInt32("CustomerId");
            string json = context.Session.GetString("Cart");
            var products=JsonConvert.DeserializeObject<List<ProcessOrder>>(json);
            FinalOrder finalOrder = new FinalOrder();
            finalOrder.CustomerId = customerId.Value;
            finalOrder.PaymentMode = paymentmode;
            finalOrder.products = products;

                       



            string json1 = JsonConvert.SerializeObject(finalOrder);
            HttpContent content = new StringContent(json1, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("Booking/Invoice", content).Result;

            json1=response.Content.ReadAsStringAsync().Result;
            InvoiceNo=JsonConvert.DeserializeObject<InvoiceDetails>(json1);
            return finalOrder;
        }
    }
}
