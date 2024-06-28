namespace RecipeApp
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        public double OriginalQuantity { get; set; }

        public void ResetQuantity()
        {
            Quantity = OriginalQuantity;
        }
    }
}
