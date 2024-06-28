using System;
using System.Linq;
using System.Windows;

namespace RecipeApp
{
    public partial class AddRecipeWindow : Window
    {
        private RecipeProgram recipeManager;

        public AddRecipeWindow(RecipeProgram recipeManager)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string name = RecipeName.Text;
            string ingredientsText = Ingredients.Text;
            string stepsText = Steps.Text;

            // Split ingredients and steps
            var ingredients = ingredientsText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(line => line.Split(','))
                                             .Select(parts => new Ingredient
                                             {
                                                 Name = parts[0],
                                                 Quantity = double.Parse(parts[1]),
                                                 Unit = parts[2],
                                                 Calories = double.Parse(parts[3]),
                                                 FoodGroup = parts[4]
                                             }).ToList();

            var steps = stepsText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select((description, index) => new Step
                                 {
                                     Number = index + 1,
                                     Description = description
                                 }).ToList();

            var recipe = new Recipe
            {
                Name = name,
                Ingredients = ingredients,
                Steps = steps
            };

            recipeManager.AddRecipe(recipe);
            MessageBox.Show("Recipe added successfully!");
            this.Close();
        }
    }
}
