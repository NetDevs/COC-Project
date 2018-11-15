using ApparelStoreApplication.Models;
using ApparelStoreWebService.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApparelStoreWebService.Models
{
    public class BookingService
    {
        ApparelStoreContext context;
        public BookingService(ApparelStoreContext context)
        {
            this.context = context;
        }

        public InvoiceDetails Invoice(FinalOrder finalOrder)
        {
            int sum = 0;
            Orders orders = new Orders();
            orders.CustomerId = finalOrder.CustomerId;
            orders.OrderDate = DateTime.Now;
            orders.DeliveryDate = DateTime.Now.AddDays(7);

        
            for(int i=0;i<finalOrder.products.Count;i++)
            {
               sum += finalOrder.products[i].Quantity * finalOrder.products[i].Price;
             
            }
            orders.TotalAmount = sum;
            context.Orders.Add(orders);
            context.SaveChanges();
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            ProductOrderDetails[] products = new ProductOrderDetails[finalOrder.products.Count];
            for (int i = 0; i < finalOrder.products.Count; i++)
            {
                products[i] = new ProductOrderDetails()
                {
                    OrderId = orders.OrderId,
                    ProductId = finalOrder.products[i].ProductId,
                    Price = finalOrder.products[i].Price,
                    Quantity = finalOrder.products[i].Quantity

                };
            }
            context.ProductOrderDetails.AddRange(products);

            Payment payment = new Payment();
            payment.Method = finalOrder.PaymentMode;
            payment.OrderId = orders.OrderId;
            payment.PaymentDate = DateTime.Now;

            context.Payment.Add(payment);
            context.SaveChanges();
            Customer customer=context.Customer.SingleOrDefault(c => c.CustomerId == finalOrder.CustomerId);
            customer.Orders = null;
            InvoiceDetails details = new InvoiceDetails();
            details.customer = customer;
            details.InvoiceNo = payment.InvoiceNo;
            return details;
        }

    }
}
