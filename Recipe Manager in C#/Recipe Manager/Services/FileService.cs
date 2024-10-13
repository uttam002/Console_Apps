using RecipeManager.Models;
using System.Text.Json;

namespace RecipeManager.Services
{
    public class FileService
    {
        private readonly string _filePath = "recipes.json";

        public void SaveRecipes(List<Recipe> recipes)
        {
            var jsonData = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }

        public List<Recipe> LoadRecipes()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Recipe>();
            }

            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Recipe>>(jsonData);
        }
    }
}
