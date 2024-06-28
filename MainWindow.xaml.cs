using System.Windows;
using RecipeApp;

namespace RecipeApp
{
    public partial class MainWindow : Window
    {
        RecipeProgram recipeProgram = new RecipeProgram();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(recipeProgram);
            addRecipeWindow.Show();
        }

        private void ViewRecipeList_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to View Recipe List window
            RecipeListWindow viewRecipeListWindow = new RecipeListWindow(recipeProgram);
            viewRecipeListWindow.Show();
        }
    }
}
