using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreLibrary;
using ApparelStoreWebService.Models;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace ApparelStoreWebService.Controllers
{
   // [Route("api/[controller]")]
    [Route("Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        AdminService service;
        ApparelStoreContext context;
        public AdminController(ApparelStoreContext context)
        {
            this.context = context;
            service = new AdminService(this.context);
        }

       // ApparelStoreContext context;
        //public AdminController()
        //{
        //    context = new ApparelStoreContext();
        //    service = new AdminService(this.context);
        //}
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate(Credentials credentials)
        {
            int result=service.Authenticate(credentials);
            if (result == 0)
                return NotFound();
            else
                return Ok(result);
          
        }

        [HttpPost]
        [Route("AddDetails")]
        public IActionResult AddDetails(UserDetails userdetails)
        {
            string result = service.AddDetails(userdetails);

            return Content(result);

        }
      
    }
}
