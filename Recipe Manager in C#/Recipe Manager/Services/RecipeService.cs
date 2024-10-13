using RecipeManager.Models;
using RecipeManager.Services;
using System.Linq;

namespace RecipeManager.Services
{
    public class RecipeService
    {
        private List<Recipe> _recipes;
        private FileService _fileService;

        public RecipeService()
        {
            _fileService = new FileService();
            _recipes = _fileService.LoadRecipes();
        }

        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
            _fileService.SaveRecipes(_recipes);
        }

        public void DeleteRecipe(string name)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
            if (recipe != null)
            {
                _recipes.Remove(recipe);
                _fileService.SaveRecipes(_recipes);
                Console.WriteLine($"Recipe {name} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        public void EditRecipe(string name)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            Console.WriteLine("Enter new recipe name (leave blank to keep unchanged):");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName)) recipe.Name = newName;

            Console.WriteLine("Enter new category (leave blank to keep unchanged):");
            string newCategory = Console.ReadLine();
            if (!string.IsNullOrEmpty(newCategory)) recipe.Category = newCategory;

            Console.WriteLine("Enter new instructions (leave blank to keep unchanged):");
            string newInstructions = Console.ReadLine();
            if (!string.IsNullOrEmpty(newInstructions)) recipe.Instructions = newInstructions;

            _fileService.SaveRecipes(_recipes);
            Console.WriteLine("Recipe updated successfully.");
        }

        public List<Recipe> SearchRecipeByName(string name)
        {
            return _recipes.Where(r => r.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Recipe> SearchRecipeByIngredient(string ingredientName)
        {
            return _recipes.Where(r => r.Ingredients.Any(i => i.Name.ToLower() == ingredientName.ToLower())).ToList();
        }

        public List<Recipe> GetAllRecipes()
        {
            return _recipes;
        }

        public void MarkRecipeAsFavorite(string name)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
            if (recipe != null)
            {
                recipe.MarkAsFavorite();
                _fileService.SaveRecipes(_recipes);
                Console.WriteLine($"Recipe {name} marked as favorite.");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        public void RemoveFavorite(string name)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
            if (recipe != null)
            {
                recipe.RemoveFavorite();
                _fileService.SaveRecipes(_recipes);
                Console.WriteLine($"Recipe {name} removed from favorites.");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
    }
}
