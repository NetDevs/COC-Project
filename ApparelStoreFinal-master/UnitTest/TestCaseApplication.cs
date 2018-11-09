using ApparelStoreApplication.Controllers;
using ApparelStoreLibrary;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApparelStoreUnitTest
{
    [TestClass]
    public class TestCaseApplication
    {
        ApparelStoreContext context;
        AdminController controllers;

        public TestCaseApplication()
        {
            NullLogger<AdminController> logger = new NullLogger<AdminController>();
            context = new ApparelStoreContext();
            controllers = new AdminController(logger);
        }
        [TestMethod]
        public void SignUpNewUser()
        {
            UserDetails details = new UserDetails() { Address = "delhi-87", Email = "Vidushi@gmail.com", Name = "Ram", Password = "123", Phone = 6543 };
            var result = (RedirectToActionResult) controllers.Signup(details);
            Assert.AreEqual("Login", result.ActionName);            
        }
        [TestMethod]
        public void SignUpDuplicateEmail()
        {
            UserDetails details = new UserDetails() { Address = "delhi-87", Email = "Nikhil@gmail.com", Name = "Ram", Password = "123", Phone = 6543 };
            var result = (RedirectToActionResult)controllers.Signup(details);
            Assert.AreEqual("Login", result.ActionName);
        }
        [TestMethod]
        public void LoginValid()
        {
            Credentials credentials = new Credentials() { Email = "Ajay@gmail.com", Password = "1234" };
            var result = (RedirectToActionResult)controllers.Login(credentials);
            Assert.AreEqual("Search", result.ActionName);
        }
        [TestMethod]
        public void LoginInvalid()
        {
            Credentials credentials = new Credentials() { Email = "123Ajay@gmail.com", Password = "1234" };
            var result = (ViewResult)controllers.Login(credentials);
            Assert.AreEqual("Login", result.ViewName);
        }

    }
}
