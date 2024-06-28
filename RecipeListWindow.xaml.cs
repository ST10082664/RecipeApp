using System.Windows;
using System.Linq;
using RecipeApp;

namespace RecipeApp
{
    public partial class RecipeListWindow : Window
    {
        private RecipeProgram recipeProgram;

        public RecipeListWindow(RecipeProgram recipeProgram)
        {
            InitializeComponent();
            this.recipeProgram = recipeProgram;
            LoadRecipeList();
        }

        private void LoadRecipeList()
        {
            RecipeListBox.ItemsSource = recipeProgram.GetRecipes().Select(r => r.Name).ToList();
        }

        private void RecipeListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Handle recipe selection if needed
        }

        private void ViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is string selectedRecipe)
            {
                RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(recipeProgram, selectedRecipe);
                recipeDetailsWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select a recipe to view.");
            }
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem is string selectedRecipe)
            {
                recipeProgram.DeleteRecipe(selectedRecipe);
                LoadRecipeList();
                MessageBox.Show("Recipe deleted successfully.");
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.");
            }
        }
    }
}
