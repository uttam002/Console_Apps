using Tic_Tac_Toc_Game.Models;

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game(); 
        Grid grid = new Grid();

        bool choice = grid.WelcomeGrid();

        if (choice)
        {
            Console.Clear();
            // basic console output 
            Console.WriteLine("Hello Gamer Lets play with me ., my name is Lucifer ,i'm uttam's buddy!!!");
            Console.WriteLine();
            Console.WriteLine();
            

            //game.PlaySinglePlayerGame();
        }
        else 
        {
            //game.PlayTwoPlayerGame();
        }
        Console.WriteLine("Press enter to exsit....");
        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.Enter)
        {
            Environment.Exit(0);
        }

    }
}
    