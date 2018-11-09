using ApparelStoreLibrary;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApparelStoreWebService.Models
{
    public class AdminService
    {
        ApparelStoreContext context;
        
        public AdminService(ApparelStoreContext context)
        {
            this.context = context;
          
        }

        //public List< Category> GetCategories()
        //{
        //    var result = (from c in context.Category select c).ToList();
        //    return result;
        //}

        public int Authenticate(Credentials credentials)
        {
            var result = (from c in context.Customer
                         where
                        c.Email == credentials.Email && c.Password == credentials.Password
                         select c.CustomerId).FirstOrDefault();
            return result;
             

        }
    

        public string AddDetails(UserDetails userdetails)
        {
            Customer customer;

            var result = context.Customer.SingleOrDefault(c => c.Email == userdetails.Email);
             
            if (result != null)
                return "Duplicate Email";
            else
            {

                customer = new Customer()
                {
                    Email = userdetails.Email,
                    Name = userdetails.Name,
                    Password = userdetails.Password,
                    Phone = (long)userdetails.Phone,
                    Address = userdetails.Address


                };

                context.Customer.Add(customer);
                var entry = context.SaveChanges();
                return entry.ToString();
            }

        }

    }
}
