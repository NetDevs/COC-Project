using ApparelStoreApplication.Models;
using ApparelStoreLibrary;
using ApparelStoreWebService.Controllers;
using ApparelStoreWebService.Models;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static int InvoiceNo=0;
        ApparelStoreContext context;
        AdminController controller;
        SearchServiceController searchcontroller;
        BookingController bookingController;

        public UnitTest1()
        {
            context = new ApparelStoreContext();
            controller = new AdminController(this.context);
            searchcontroller = new SearchServiceController(this.context);
            bookingController = new BookingController(this.context);
        }

        [TestMethod]

        public void SignupPageTestDuplicateEmail()
        {
            UserDetails details = new UserDetails() { Address = "delhi-87", Email = "Nikhil@gmail.com", Name = "Ram", Password = "123", Phone = 6543 };
            var result =(ContentResult) controller.AddDetails(details);
            Assert.AreEqual("Duplicate Email", result.Content);
        }

        [TestMethod]

        public void SignupPageTestNewUserUniqueEmail()
        {
            UserDetails details = new UserDetails() { Address = "delhi-87", Email = "book151@book.com", Name = "Ram", Password = "123", Phone = 6543 };
            var result = (ContentResult)controller.AddDetails(details);
            Assert.AreEqual("1", result.Content);
        }

        [TestMethod]

        public void AuthenticateNotFound()
        {
            Credentials credentials = new Credentials() { Email = "1Nikhil@gmail.com", Password = "1234" };
            var result = controller.Authenticate(credentials);
            Assert.IsInstanceOfType(result,typeof(NotFoundResult));
        }
          [TestMethod]
        public void AuthenticateOkResult()
        {
            Credentials credentials = new Credentials() { Email = "Nikhil@gmail.com", Password = "1234" };
            var result = controller.Authenticate(credentials);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public void GetCategoryresult()
        {
            var result =searchcontroller.GetCategories();
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void GetSubCategoryresult()
        {
            var result = searchcontroller.GetSubCategories(3);
            Assert.AreEqual(3, result.Count);
        }
        [TestMethod]
        public void GetProducts()
        {
            SubCategory subcategory = new SubCategory() { CategoryId = 1, SubCategoryId = 2, SubCategoryName = "BottomWear" };
            var result = searchcontroller.GetProducts(subcategory);
            Assert.AreEqual(1,result.Count);
        }
        [TestMethod]
        public void Invoice()
        {
            ProcessOrder po = new ProcessOrder()
            {
                ProductImage = "https://www.google.co.in/search?q=product+images&tbm=isch&source=iu&ictx=1&fir=Ys6s1aKrzB6hrM%253A%252ChoD76SE7hB_ZTM%252C_&usg=AI4_-kRULqtxH-vZZChrfKQOclXWU2y_hw&sa=X&ved=2ahUKEwjIsurpndjeAhVKQY8KHVJ6CvkQ9QEwAnoECAAQCA#imgrc=Ys6s1aKrzB6hrM:",
                Title = "EarPhones",
                Price = 1200,
                Quantity = 5,
                ReorderLevel = 10,
                Description = "Nice EarPhones",
                CategoryId = 62,
                SubCategoryId = 64,
                ProductId=129,
                sum=6000

            };
            List<ProcessOrder> lst = new List<ProcessOrder>();
            lst.Add(po);
           
            FinalOrder finalOrder = new FinalOrder() { products = lst, CustomerId =100 , PaymentMode = "COD" };
            var result = bookingController.Invoice(finalOrder) as OkObjectResult;
            InvoiceDetails details = (InvoiceDetails)result.Value;
            InvoiceNo = details.InvoiceNo;
            Assert.IsInstanceOfType(result.Value, typeof(InvoiceDetails));
        }
        [ClassCleanup]
        public static void CleanUp()
        {
            ApparelStoreContext context = new ApparelStoreContext();
            if (InvoiceNo !=0)
            {
                var payment=context.Payment.SingleOrDefault(c => c.InvoiceNo == InvoiceNo);
                var orderdetails = context.ProductOrderDetails.Where(c => c.OrderId == payment.OrderId).ToArray();
                var order = context.Orders.SingleOrDefault(c => c.OrderId == payment.OrderId);

                context.Payment.Remove(payment);
                context.ProductOrderDetails.RemoveRange(orderdetails);
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }
    }
}