using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DrinkInfo
{
    class Category
    {
        public List<Drink>? drinks      { get; set; }
    }
    class Drink
    {
        public string? strDrink         { get; set; }
        public string? strGlass         { get; set; }
        public string? strInstructions  { get; set; }

        // Up to 15 ingredients, I don't know why the hell this isnt a list in the api, they're literally seperate properties
        public string? strIngredient1   { get; set; }
        public string? strIngredient2   { get; set; }
        public string? strIngredient3   { get; set; }
        public string? strIngredient4   { get; set; }
        public string? strIngredient5   { get; set; }
        public string? strIngredient6   { get; set; }
        public string? strIngredient7   { get; set; }
        public string? strIngredient8   { get; set; }
        public string? strIngredient9   { get; set; }
        public string? strIngredient10  { get; set; }
        public string? strIngredient11  { get; set; }
        public string? strIngredient12  { get; set; }
        public string? strIngredient13  { get; set; }
        public string? strIngredient14  { get; set; }
        public string? strIngredient15  { get; set; }
        // Measurements
        public string? strMeasure1      { get; set; }
        public string? strMeasure2      { get; set; }
        public string? strMeasure3      { get; set; }
        public string? strMeasure4      { get; set; }
        public string? strMeasure5      { get; set; }
        public string? strMeasure6      { get; set; }
        public string? strMeasure7      { get; set; }
        public string? strMeasure8      { get; set; }
        public string? strMeasure9      { get; set; }
        public string? strMeasure10     { get; set; }
        public string? strMeasure11     { get; set; }
        public string? strMeasure12     { get; set; }
        public string? strMeasure13     { get; set; }
        public string? strMeasure14     { get; set; }
        public string? strMeasure15     { get; set; }
        public string? idDrink          { get; set; }

        public List<string> GetIngredients()
        {
            List<string> result = new List<string> { 
                strIngredient1, strIngredient2, strIngredient3, strIngredient4
                ,strIngredient5, strIngredient6, strIngredient7, strIngredient8
                ,strIngredient9, strIngredient10, strIngredient11, strIngredient12
                ,strIngredient13, strIngredient14, strIngredient15 };
            

            return result.Where(str => !string.IsNullOrEmpty(str)).ToList();
        }

        public List<string> GetMeasurements()
        {
            List<string> result = new List<string> {
                strMeasure1, strMeasure2, strMeasure3, strMeasure4, strMeasure5
                ,strMeasure6, strMeasure7, strMeasure8, strMeasure9, strMeasure10
                ,strMeasure11, strMeasure12, strMeasure13, strMeasure14, strMeasure15 };

            return result.Where(str => !string.IsNullOrEmpty(str)).ToList();

        }
    }
}
