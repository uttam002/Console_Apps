using FlashcardApp.Services;
using FlashcardApp.Utils;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var flashcardService = new FlashcardService();
        string filePath = "flashcards.json";

        // Load saved flashcards (if any)
        flashcardService.LoadFlashcards(filePath);

        while (true)
        {
            Console.WriteLine("\n--- Flashcard App ---");
            Console.WriteLine("1. Add Flashcard");
            Console.WriteLine("2. View Flashcards");
            Console.WriteLine("3. Start Test (Randomized)");
            Console.WriteLine("4. Review Incorrect Answers");
            Console.WriteLine("5. Save & Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddFlashcard(flashcardService);
                    break;
                case "2":
                    flashcardService.ViewFlashcards();
                    break;
                case "3":
                    flashcardService.StartTest(randomize: true);
                    break;
                case "4":
                    flashcardService.ReviewIncorrectAnswers();
                    break;
                case "5":
                    flashcardService.SaveFlashcards(filePath);
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddFlashcard(FlashcardService flashcardService)
    {
        Console.Write("Enter the question: ");
        string question = Console.ReadLine();

        Console.Write("Enter the answer: ");
        string answer = Console.ReadLine();

        Console.Write("Enter the category: ");
        string category = Console.ReadLine();

        Console.Write("Enter tags (comma-separated): ");
        var tagsInput = Console.ReadLine();
        var tags = string.IsNullOrWhiteSpace(tagsInput) ? new List<string>() : new List<string>(tagsInput.Split(','));

        flashcardService.AddFlashcard(question, answer, category, tags);
    }
}
