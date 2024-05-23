using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkInfo
{
    internal class Menu
    {
        public static void MainMenu()
        {
            var category = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Drink Categories")
                    .PageSize(11)
                    .AddChoices(new[]
                    {
                        "Ordinary Drink", "Cocktail", "Shake"
                        ,"Other/Unknown", "Cocoa", "Shot", "Coffee / Tea"
                        ,"Homemade Liqueur", "Punch / Party Drink", "Beer"
                        ,"Soft Drink"
                    }));

            DrinkMenu(Requests.Category + category);
        }

        private static async void DrinkMenu(string category)
        {
            AllDrinks? allDrinks = await API.GetAsync(category);
            if(allDrinks != null && allDrinks.drinks != null) Console.WriteLine(allDrinks.drinks[0].strDrink);
        }
    }
}
