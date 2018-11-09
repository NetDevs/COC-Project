using System;
using System.Collections.Generic;
using System.Text;

namespace ApparelStoreLibrary
{
    public class UserDetails
    {

        public string Name { get; set; }
        public double Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}
        public string Address { get; set; }
        public UserDetails()
        {
            Name = "";
            Phone = 0;
            Email = "";
            Password = "";
            Address = "";
        }

    }
}
