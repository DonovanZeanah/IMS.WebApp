using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class Http
    {
        public static async Task<string> Get(string url)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(url);
            using var content = response.Content;
            return await content.ReadAsStringAsync();
        }

        public static async Task<string> Post(string url, string data)
        {
            using var client = new HttpClient();
            using var content = new StringContent(data, Encoding.UTF8, "application/json");
            using var response = await client.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }
    }

}
