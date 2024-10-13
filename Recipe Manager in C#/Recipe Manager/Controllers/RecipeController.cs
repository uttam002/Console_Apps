using RecipeManager.Models;
using RecipeManager.Services;

namespace RecipeManager.Controllers
{
    public class RecipeController
    {
        private RecipeService _recipeService;

        public RecipeController()
        {
            _recipeService = new RecipeService();
        }

        public void AddRecipe()
        {
            Console.Write("Enter recipe name: ");
            string name = Console.ReadLine();

            List<Ingredient> ingredients = new List<Ingredient>();
            Console.WriteLine("Add ingredients (type 'done' to finish):");
            while (true)
            {
                Console.Write("Ingredient name: ");
                string ingredientName = Console.ReadLine();
                if (ingredientName.ToLower() == "done") break;

                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Unit: ");
                string unit = Console.ReadLine();

                ingredients.Add(new Ingredient(ingredientName, quantity, unit));
            }

            Console.Write("Enter instructions: ");
            string instructions = Console.ReadLine();

            Console.Write("Enter category (e.g., Dessert, Main Course): ");
            string category = Console.ReadLine();

            _recipeService.AddRecipe(new Recipe(name, ingredients, instructions, category));
        }

        public void DisplayAllRecipes()
        {
            List<Recipe> recipes = _recipeService.GetAllRecipes();
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            foreach (var recipe in recipes)
            {
                recipe.DisplayRecipe();
                Console.WriteLine("----------------------------");
            }
        }

        public void SearchRecipeByName()
        {
            Console.Write("Enter recipe name to search: ");
            string name = Console.ReadLine();
            var recipes = _recipeService.SearchRecipeByName(name);
            DisplaySearchResults(recipes);
        }

        public void SearchRecipeByIngredient()
        {
            Console.Write("Enter ingredient name to search: ");
            string ingredientName = Console.ReadLine();
            var recipes = _recipeService.SearchRecipeByIngredient(ingredientName);
            DisplaySearchResults(recipes);
        }

        private void DisplaySearchResults(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
            }
            else
            {
                foreach (var recipe in recipes)
                {
                    recipe.DisplayRecipe();
                    Console.WriteLine("----------------------------");
                }
            }
        }

        public void EditRecipe()
        {
            Console.Write("Enter recipe name to edit: ");
            string name = Console.ReadLine();
            _recipeService.EditRecipe(name);
        }

        public void DeleteRecipe()
        {
            Console.Write("Enter recipe name to delete: ");
            string name = Console.ReadLine();
            _recipeService.DeleteRecipe(name);
        }

        public void MarkAsFavorite()
        {
            Console.Write("Enter recipe name to mark as favorite: ");
            string name = Console.ReadLine();
            _recipeService.MarkRecipeAsFavorite(name);
        }

        public void RemoveFavorite()
        {
            Console.Write("Enter recipe name to remove from favorites: ");
            string name = Console.ReadLine();
            _recipeService.RemoveFavorite(name);
        }
    }
}
