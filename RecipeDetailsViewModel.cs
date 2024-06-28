using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp.ViewModels
{
    public class RecipeDetailsViewModel
    {
        private Recipe recipe;

        public RecipeDetailsViewModel(Recipe recipe)
        {
            this.recipe = recipe;
            PopulatePieChart();
        }

        public SeriesCollection FoodGroupPieSeries { get; set; }

        private void PopulatePieChart()
        {
            // Example logic to populate pie chart data
            var groupedByFoodGroup = recipe.Ingredients
                .GroupBy(i => i.FoodGroup)
                .Select(g => new
                {
                    FoodGroup = g.Key,
                    TotalCalories = g.Sum(i => i.Calories)
                });

            FoodGroupPieSeries = new SeriesCollection();
            foreach (var group in groupedByFoodGroup)
            {
                FoodGroupPieSeries.Add(new PieSeries
                {
                    Title = group.FoodGroup,
                    Values = new ChartValues<double> { group.TotalCalories },
                    DataLabels = true
                });
            }
        }
    }
}
