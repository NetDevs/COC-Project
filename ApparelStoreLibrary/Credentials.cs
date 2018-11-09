using System;

namespace ApparelStoreLibrary
{
    public class Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Credentials()
        {
            Email = "";
            Password = "";
        }
        //public Credentials(string UserId, string Password)
        //{
        //    this.UserId = UserId;
        //    this.Password = Password;
        //}
        //public string SetCredentials()
        //{

        //}
    }

}
