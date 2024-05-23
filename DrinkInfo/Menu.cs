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
        public static async Task MainMenu()
        {
            string? category;
            do
            {
                category = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Drink Categories")
                    .PageSize(12)
                    .AddChoices(new[]
                    {
                        "Ordinary Drink", "Cocktail", "Shake"
                        ,"Other/Unknown", "Cocoa", "Shot", "Coffee / Tea"
                        ,"Homemade Liqueur", "Punch / Party Drink", "Beer"
                        ,"Soft Drink", "Random", "Exit"
                    }));
                if(category != "Exit")
                    if (category == "Random") await DrinkMenu(Requests.Random);
                    else await DrinkMenu(Requests.Category + category);
            } while (category != "Exit");
            Console.WriteLine("Goodbye!");
            
        }

        private static async Task DrinkMenu(string category)
        {
            AllDrinks? allDrinks  = await API.GetAsync(category);
            if(allDrinks != null && allDrinks.drinks != null && allDrinks.drinks.Count > 0)
            {
                List<string> drinkList = allDrinks.drinks.Select(drink => drink.strDrink).Where(str => str != null).ToList();
                drinkList.Add("Go back");
                string? chosenDrink;
                do
                {
                    chosenDrink = AnsiConsole.Prompt(
                       new SelectionPrompt<string>()
                           .Title("Drink Categories")
                           .PageSize(10)
                           .AddChoices(drinkList));
                } while (chosenDrink != "Go back");
               
            } else
            {
                Console.WriteLine("No drinks found");
            }
        }
    }
}
