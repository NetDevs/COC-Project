using ApparelStoreLibrary;
using ApparelStoreWebService.Controllers;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        ApparelStoreContext context;
        AdminController controller;
        SearchServiceController searchcontroller;

        public UnitTest1()
        {
            context = new ApparelStoreContext();
            controller = new AdminController(this.context);
            searchcontroller = new SearchServiceController(this.context);
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

    }
}