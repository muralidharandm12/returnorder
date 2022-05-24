using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReturnOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReturnOrder.Repositories
{
    public class AuthRepo:IAuthRepo
    {
        private readonly IConfiguration _configuration;
        public AuthRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetToken(User user)
        {
            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://20.241.144.245");
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                var response = client.PostAsync("api/Authorization", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var token = response.Content.ReadAsStringAsync().Result;
                    return token;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        

    }
}
