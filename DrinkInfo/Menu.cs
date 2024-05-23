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
            var menu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Drink Categories")
                    .PageSize(11)
                    .AddChoices(new[]
                    {
                        "Ordinary Drink", "Cocktail", "Milk / Float / Shake"
                        ,"Other/Unknown", "Cocoa", "Shot", "Coffee / Tea"
                        ,"Homemade Liqueur", "Punch / Party Drink", "Beer"
                        ,"Soft Drink / Soda"
                    }));
        }
    }
}
