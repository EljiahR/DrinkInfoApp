using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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
        public static async Task<AllDrinks?> GetAsync(string apiCall)
        {
            return await client.GetFromJsonAsync<AllDrinks>(apiCall);
        }


    }
}
