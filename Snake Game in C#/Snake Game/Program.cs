using System;
using System.Collections.Generic;
using System.Threading;

class SnakeGame
{
    // Define the screen width and height
    static int screenWidth = 30;
    static int screenHeight = 20;

    // Define the grid for the snake and food
    static char[,] grid = new char[screenHeight, screenWidth];//grid for snake and food -> consider it as (x,y) axis of graph page
    static List<(int row, int col)> snake = new List<(int row, int col)>();//snake body -> consider it as a list of points
    static (int row, int col) food;//food -> consider it as a point

    // Define the initial length of the snake, the direction of the snake, and the random generator
    static int snakeLength = 2;//initial length of snake
    static (int row, int col) direction = (0, 1); // Initially moving right
    static Random random = new Random();//for food apear in random place

    static bool gameOver = false;
    static int Speed = 100; // Controls the game speed in miliseconds

    static void Main()
    {
        Console.CursorVisible = false;//hide the cursor
        InitializeGame();//initialize the game
        while (!gameOver)
        {
            DrawGrid();//draw the grid
            Input();//take the input from user to change the direction of snake with arrow keys
            MoveSnake();//move the snake according to it
            CheckCollision();//check if snake collide with wall or itself
            Thread.Sleep(Speed); // Controls the game speed
        }
        Console.Clear();
        Console.WriteLine("Game Over! Press any key to exit...");
        Console.ReadKey();
    }
    static void InitializeGame()
    {
        Console.Clear();

        string title = "Welcome to Snake Game!";
        int centerX = screenWidth / 2 - (title.Length / 2);//center of screen except title
        int centerY = screenHeight / 2;//center of screen
        bool flag = true;//show title or not

        while (true)//for blinking effect of title
        {
            Console.WriteLine(new string('-', screenWidth + 2));//top border of screen
            for (int i = 0; i < centerY - 1; i++)Console.WriteLine("|" + new string(' ', screenWidth) + "|");//for empty space and left and right border of screen

            //logic of blinking effect of title
            if(flag) Console.WriteLine("|" + new string(' ', centerX) + title + new string(' ', screenWidth - centerX - title.Length) + '|');//title at center of screen 
            else Console.WriteLine("|" + new string(' ', screenWidth) + "|");


            for (int i = centerY; i < screenHeight - 1; i++)Console.WriteLine("|" + new string(' ', screenWidth) + "|");//rest of screen with left and right border

            Console.WriteLine(new string('-', screenWidth + 2));//bottom border of screen

            Console.WriteLine("\nPress Enter to start...");

            //if user press enter then break the loop
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter) break;

            //for blinking effect
            flag= !flag;
            Thread.Sleep(450);//in miliseconds
            Console.Clear();
        }
        //clear the screen
        Console.Clear();
        StartGame();//let's start the game
    }
    static void StartGame()
    {
        // Initialize the grid with empty spaces
        for (int i = 0; i < screenHeight; i++)
        {
            for (int j = 0; j < screenWidth; j++)
            {
                grid[i, j] = ' ';
            }
        }

        //for intion potion of snake
        int startRow = screenHeight / 2;
        int startCol = screenWidth / 2;

        // Initialize the snake at the center of the screen
        for (int i = 0; i < snakeLength; i++)
        {
            snake.Add((startRow, startCol - i));
        }
        // Place the food in a random position
        PlaceFood();
    }

    static void DrawGrid()
    {
        Console.SetCursorPosition(0,0);//set the cursor position at top left corner

        // Top border
        Console.WriteLine(new string('-', screenWidth + 2));

        // Draw the grid with snake and food inside it
        for (int i = 0; i < screenHeight; i++)
        {
            Console.Write("|"); // Left border

            for (int j = 0; j < screenWidth; j++)
            {
                if (snake.Contains((i, j)))
                {
                    Console.Write("0");//snake body
                }
                else if (food == (i, j))
                {
                    Console.Write("*");//food
                }
                else
                {
                    Console.Write(grid[i, j]);//empty space
                }
            }

            Console.WriteLine("|"); // Right border
        }

        // Bottom border
        Console.WriteLine(new string('-', screenWidth + 2));
    }

    //take the input from user to change the direction of snake with arrow keys
    static void Input()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;//read the key from user

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    //this condition is to avoid the snake to move in opposite direction
                    if (direction != (1, 0)) direction = (-1, 0);//change the direction of snake at uper side
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != (-1, 0)) direction = (1, 0);//change the direction of snake at down side
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != (0, 1)) direction = (0, -1);//change the direction of snake at left side
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != (0, -1)) direction = (0, 1);//change the direction of snake at right side
                    break;
            }
        }
    }

    static void MoveSnake()
    {
        (int newRow, int newCol) = (snake[0].row + direction.row, snake[0].col + direction.col);//new position of snake head
        snake.Insert(0, (newRow, newCol));//insert the new position of snake head

        if (newRow == food.row && newCol == food.col) PlaceFood();//if snake eat the food
        else  snake.RemoveAt(snake.Count - 1);//remove the last element of snake body
        
    }

    static void PlaceFood()
    {
        int row, col;//for food position
        do
        {
            row = random.Next(0, screenHeight);//random row
            col = random.Next(0, screenWidth);//random cols
        } while (snake.Contains((row, col)));//if food is on snake body then again generate the random position of food
        food = (row, col);//set the food position
    }

    static void CheckCollision()//check if snake collide with wall or itself
    {
        (int headRow, int headCol) = snake[0];//head of snake

        if (headRow < 0 || headRow >= screenHeight || headCol < 0 || headCol >= screenWidth)//if snake collide with wall
        {
            gameOver = true;
        }

        for (int i = 1; i < snake.Count; i++)
        {
            if (snake[i] == (headRow, headCol))//if snake collide with itself
            {
                gameOver = true;
                break;
            }
        }
    }
}
