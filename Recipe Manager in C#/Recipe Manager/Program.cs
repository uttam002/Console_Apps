using RecipeManager.Controllers;

class Program
{
    static void Main(string[] args)
    {
        var controller = new RecipeController();

        while (true)
        {
            Console.WriteLine("\n--- Recipe Manager ---");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. Display All Recipes");
            Console.WriteLine("3. Search Recipe by Name");
            Console.WriteLine("4. Search Recipe by Ingredient");
            Console.WriteLine("5. Edit Recipe");
            Console.WriteLine("6. Delete Recipe");
            Console.WriteLine("7. Mark Recipe as Favorite");
            Console.WriteLine("8. Remove Favorite");
            Console.WriteLine("9. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    controller.AddRecipe();
                    break;
                case "2":
                    controller.DisplayAllRecipes();
                    break;
                case "3":
                    controller.SearchRecipeByName();
                    break;
                case "4":
                    controller.SearchRecipeByIngredient();
                    break;
                case "5":
                    controller.EditRecipe();
                    break;
                case "6":
                    controller.DeleteRecipe();
                    break;
                case "7":
                    controller.MarkAsFavorite();
                    break;
                case "8":
                    controller.RemoveFavorite();
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
