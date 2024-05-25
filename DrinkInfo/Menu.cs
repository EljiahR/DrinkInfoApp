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
        private static readonly List<string> _categories = new List<string> { 
            "Ordinary Drink", "Cocktail", "Shake"
            ,"Other / Unknown", "Cocoa", "Shot", "Coffee / Tea"
            ,"Homemade Liqueur", "Punch / Party Drink", "Beer"
            ,"Soft Drink", "Random", "Exit"};
        public static async Task MainMenu()
        {
            string? category;
            do
            {
                category = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Drink Categories")
                    .PageSize(13)
                    .AddChoices(_categories));
                if(category != "Exit")
                    if (category == "Random") DisplayDrinkInfo(await API.GetDrinkAsync(Requests.Random));
                    else await DrinkMenu(category);
            } while (category != "Exit");
            Console.WriteLine("Goodbye!");
            
        }

        private static async Task DrinkMenu(string selectedCategory)
        {
            Category? category  = await API.GetCategoryAsync(Requests.Category + selectedCategory);
            if(category != null && category.drinks != null && category.drinks.Count > 0)
            {
                List<string> drinkList = category.drinks.Select(drink => drink.strDrink).Where(str => !string.IsNullOrEmpty(str)).ToList(); // .Where() should fix the nullability thing what the hell
                drinkList.Add("Go back");
                string? choice;
                do
                {
                    choice = AnsiConsole.Prompt(
                       new SelectionPrompt<string>()
                           .Title(selectedCategory)
                           .PageSize(10)
                           .AddChoices(drinkList));

                    if (choice != "Go back")
                    {
                        Drink chosenDrink = category.drinks.Find(drink => drink.strDrink == choice);
                        Drink drinkInfo = await API.GetDrinkAsync(Requests.Id + chosenDrink.idDrink);
                        DisplayDrinkInfo(drinkInfo);

                    }
                } while (choice != "Go back");
               
            } else
            {
                Console.WriteLine("No drinks found");
            }
        }

        private static void DisplayDrinkInfo(Drink drink)
        {

            /*Console.WriteLine(drink.strDrink);
            foreach(var ingredient in drink.GetIngredientsWithMeasurements())
            {
                Console.WriteLine(ingredient);
            }
            */

            var drinkIngredients = new Table();
            drinkIngredients.Title(drink.strDrink);
            drinkIngredients.AddColumn("Ingredients");
            
            foreach(var ingredient in drink.GetIngredientsWithMeasurements())
            {
                drinkIngredients.AddRow(ingredient);
            }

            AnsiConsole.Write(drinkIngredients);
            if(!string.IsNullOrEmpty(drink.strInstructions))
            {
                var drinkInstructions = new Table();
                drinkInstructions.AddColumn("Instructions");
                drinkInstructions.AddRow(drink.strInstructions);
                AnsiConsole.Write(drinkInstructions);
            }
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();

            Console.Clear();
        }
    }
}
