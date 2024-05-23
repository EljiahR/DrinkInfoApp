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
        public static async Task GetAsync(string apiCall)
        {
            AllDrinks? allDrinks = await client.GetFromJsonAsync<AllDrinks>(apiCall);
            if(allDrinks == null || allDrinks.drinks == null || allDrinks.drinks.Count == 0)
            {
                Console.WriteLine("Drink not found");
            } else
            {
                Console.WriteLine(allDrinks.drinks[0].strDrink + "\n");
            }


        }


    }
}
