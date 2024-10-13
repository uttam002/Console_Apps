namespace RecipeManager.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }
        public string Category { get; set; }
        public bool IsFavorite { get; set; }

        public Recipe(string name, List<Ingredient> ingredients, string instructions, string category)
        {
            Name = name;
            Ingredients = ingredients;
            Instructions = instructions;
            Category = category;
            IsFavorite = false; // default value
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name} (Category: {Category})");
            Console.WriteLine(IsFavorite ? "★ Favorite Recipe ★" : "");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine($"Instructions: {Instructions}");
        }

        public void MarkAsFavorite()
        {
            IsFavorite = true;
        }

        public void RemoveFavorite()
        {
            IsFavorite = false;
        }
    }
}
