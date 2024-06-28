using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class RecipeDetailsWindow : Window
    {
        private RecipeProgram recipeProgram;
        private string recipeName;

        public RecipeDetailsWindow(RecipeProgram recipeProgram, string recipeName)
        {
            InitializeComponent();
            this.recipeProgram = recipeProgram;
            this.recipeName = recipeName;
            LoadRecipeDetails();
        }

        private void LoadRecipeDetails()
        {
            var recipe = recipeProgram.GetRecipe(recipeName);
            RecipeTitle.Text = recipe.Name;
            IngredientsListBox.ItemsSource = recipe.Ingredients.Select(i => $"{i.Name}: {i.Quantity} {i.Unit} ({i.Calories} calories, {i.FoodGroup})").ToList();
            StepsListBox.ItemsSource = recipe.Steps.Select(s => $"Step {s.Number}: {s.Description}").ToList();
            TotalCalories.Text = $"Total Calories: {recipe.CalculateTotalCalories()}";
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            if (ScaleComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                double scale = double.Parse(selectedItem.Content.ToString());
                recipeProgram.ScaleRecipe(recipeName, scale);
                LoadRecipeDetails();
            }
            else
            {
                MessageBox.Show("Please select a scale factor.");
            }
        }
        public RecipeDetailsWindow(Recipe recipe)
        {
            InitializeComponent();

            // Set DataContext to an instance of RecipeDetailsViewModel
            DataContext = new ViewModels.RecipeDetailsViewModel(recipe);
        }
    }
}
