using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Step> Steps { get; set; } = new List<Step>();

        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(i => i.Calories);
        }

        public void ScaleIngredients(double scale)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= scale;
            }
        }

        public void ResetIngredients()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }
    }
}
