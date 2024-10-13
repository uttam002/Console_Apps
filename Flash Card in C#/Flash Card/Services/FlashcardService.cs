using FlashcardApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Xml;

namespace FlashcardApp.Services
{
    public class FlashcardService
    {
        private List<Flashcard> _flashcards = new List<Flashcard>();
        private List<Flashcard> _incorrectFlashcards = new List<Flashcard>();

        public void AddFlashcard(string question, string answer, string category, List<string> tags)
        {
            var flashcard = new Flashcard(question, answer, category, tags);
            _flashcards.Add(flashcard);
            Console.WriteLine("Flashcard added successfully.");
        }

        public void ViewFlashcards()
        {
            if (_flashcards.Count == 0)
            {
                Console.WriteLine("No flashcards available.");
                return;
            }

            Console.WriteLine("\n--- Flashcard List ---");
            foreach (var flashcard in _flashcards)
            {
                Console.WriteLine(flashcard.ToString());
                Console.WriteLine("----------------------------");
            }
        }

        public void StartTest(bool randomize = true)
        {
            if (_flashcards.Count == 0)
            {
                Console.WriteLine("No flashcards to test.");
                return;
            }

            var flashcardsToTest = randomize ? _flashcards.OrderBy(x => Guid.NewGuid()).ToList() : _flashcards;
            _incorrectFlashcards.Clear();

            Console.WriteLine("\n--- Flashcard Test ---");
            int correctCount = 0;

            foreach (var flashcard in flashcardsToTest)
            {
                Console.WriteLine($"Question: {flashcard.Question}");
                Console.Write("Your Answer: ");
                string userAnswer = Console.ReadLine();

                if (userAnswer.Trim().ToLower() == flashcard.Answer.Trim().ToLower())
                {
                    flashcard.MarkCorrect();
                    correctCount++;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    flashcard.MarkIncorrect();
                    _incorrectFlashcards.Add(flashcard);
                    Console.WriteLine($"Incorrect! The correct answer is: {flashcard.Answer}");
                }
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine($"\nYou got {correctCount} out of {_flashcards.Count} correct.");
        }

        public void ReviewIncorrectAnswers()
        {
            if (_incorrectFlashcards.Count == 0)
            {
                Console.WriteLine("You did not answer any questions incorrectly.");
                return;
            }

            Console.WriteLine("\n--- Review Incorrect Answers ---");
            foreach (var flashcard in _incorrectFlashcards)
            {
                Console.WriteLine(flashcard.ToString());
                Console.WriteLine("----------------------------");
            }
        }

        public void SaveFlashcards(string filePath)
        {
            var json = JsonConvert.SerializeObject(_flashcards, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine("Flashcards saved successfully.");
        }

        public void LoadFlashcards(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                _flashcards = JsonConvert.DeserializeObject<List<Flashcard>>(json) ?? new List<Flashcard>();
                Console.WriteLine("Flashcards loaded successfully.");
            }
            else
            {
                Console.WriteLine("No saved flashcards found.");
            }
        }
    }
}
