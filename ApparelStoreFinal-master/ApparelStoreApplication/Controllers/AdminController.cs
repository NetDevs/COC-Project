using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreApplication.Models;
using ApparelStoreLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using static ApparelStoreApplication.Components.FiltersApp;

namespace ApparelStoreApplication.Controllers
{
    public class AdminController : Controller
    {
        AdminService service;
        ILogger<AdminController> log;
        public AdminController(ILogger<AdminController> log)
        {
            service = new AdminService();
            this.log = log;
        }


        
        public IActionResult Login()
        {
            return View();
        }
       [ErrorFilter]
        [HttpPost]
        public IActionResult Login(Credentials credentials)
        {
           log.LogInformation("Executing Login Method");
                int result = service.Login(credentials);
                if(result==0)
                {
                    ModelState.AddModelError("Email", "Invalid Uid Password");
                    return View("Login", credentials);
                }
          
            return RedirectToAction("Search","Search");
        }
        [ErrorFilter]
        [HttpGet]
        public IActionResult Signup()
        {
           return View();
        }
       
        [HttpPost]
        public IActionResult Signup(UserDetails userdetails)
        {
            string result = "";
            try
            {
                result = service.Signup(userdetails);
                if (result == "Duplicate Email")
                {
                    ModelState.AddModelError("Email", "User Already Exists");
                    return RedirectToAction("Login", "Admin");
                }


                return RedirectToAction("Login", "admin");
            }
            catch(Exception e)
            {
                ErrorViewModel model = new ErrorViewModel() { RequestId=e.Message };
                return View("Error", model);
            }
        }
    }
}
