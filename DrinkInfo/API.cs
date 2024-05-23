using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkInfo
{
    internal class API
    {

        private static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
        };
        public static async Task GetAsync(string apiCall)
        {
            using HttpResponseMessage response = await client.GetAsync(apiCall);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine(jsonResponse + "\n");

        }


    }
}
