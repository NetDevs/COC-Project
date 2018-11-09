using ApparelStoreLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApparelStoreApplication.Models
{
    public class AdminService
    {
        HttpClient client;
        public AdminService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50821/");
        }
        public int Login(Credentials credentials)
        {
            string json = JsonConvert.SerializeObject(credentials);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("/Admin/Authenticate", content).Result;

            if (response.IsSuccessStatusCode == false)
            {
                return 0;
            }
            return 1;
        }
        public string Signup(UserDetails userdetails)
        {
            string json = JsonConvert.SerializeObject(userdetails);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("Admin/AddDetails", content).Result;
            string message="";
            if (response.IsSuccessStatusCode == true)
            {
                message=response.Content.ReadAsStringAsync().Result;
            }
            return message;
        }
    }
}
