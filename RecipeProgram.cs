using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public class RecipeProgram
    {
        private Dictionary<string, Recipe> recipes = new Dictionary<string, Recipe>();

        public void AddRecipe(Recipe recipe)
        {
            if (recipes.ContainsKey(recipe.Name))
            {
                throw new ArgumentException("A recipe with this name already exists.");
            }

            recipes[recipe.Name] = recipe;

            // Check for calorie limit
            CheckCalorieLimit(recipe.CalculateTotalCalories());
        }

        public List<Recipe> GetRecipes()
        {
            return recipes.Values.OrderBy(r => r.Name).ToList();
        }

        public Recipe GetRecipe(string name)
        {
            if (recipes.TryGetValue(name, out var recipe))
            {
                return recipe;
            }
            throw new KeyNotFoundException("Recipe not found.");
        }

        public void DeleteRecipe(string name)
        {
            if (!recipes.Remove(name))
            {
                throw new KeyNotFoundException("Recipe not found.");
            }
        }

        public void ScaleRecipe(string name, double scale)
        {
            if (recipes.TryGetValue(name, out var recipe))
            {
                recipe.ScaleIngredients(scale);
            }
            else
            {
                throw new KeyNotFoundException("Recipe not found.");
            }
        }

        private void CheckCalorieLimit(double totalCalories)
        {
            if (totalCalories >= 300)
            {
                PrintCalorieAlert(totalCalories);
            }
        }

        private void PrintCalorieAlert(double totalCalories)
        {
            MessageBox.Show($"ALERT! {totalCalories} calories\nThis amount may be considered a light meal for many adults, but it could be appropriate for others.\nFun Fact: In science, 1 calorie (1 cal) is the unit of measure of energy contained in 1g of food. And an average adult needs 2000-2500 kcal per day and not per meal.");
        }
    }
}
