using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Expense
{
    public string Description { get; set; }
    public double Amount { get; set; }
    public string Category { get; set; }
}

class Program
{
    static List<Expense> expenses = new List<Expense>();
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nExpense Tracker");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View All Expenses");
            Console.WriteLine("3. Export Expenses");
            Console.WriteLine("4. Check Total Spent");
            Console.WriteLine("5. Check Expenses by Category");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddExpense(); break;
                case "2": ViewAllExpenses(); break;
                case "3": ExportExpenses(); break;
                case "4": CheckTotalSpent(); break;
                case "5": CheckExpensesByCategory(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice, try again."); break;
            }
        }
    }

    static void AddExpense()
    {
        Console.Write("Enter Description: ");
        string desc = Console.ReadLine();
        
        Console.Write("Enter Amount: ");
        if (!double.TryParse(Console.ReadLine(), out double amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount!");
            return;
        }
        
        Console.Write("Enter Category: ");
        string category = Console.ReadLine();
        
        expenses.Add(new Expense { Description = desc, Amount = amount, Category = category });
        Console.WriteLine("Expense added successfully!");
    }

    static void ViewAllExpenses()
    {
        if (!expenses.Any())
        {
            Console.WriteLine("No expenses recorded.");
            return;
        }

        Console.WriteLine("\nAll Expenses:");
        foreach (var exp in expenses)
        {
            Console.WriteLine($"{exp.Description} - ${exp.Amount} ({exp.Category})");
        }
    }

    static void ExportExpenses()
    {
        Console.WriteLine("Choose format: 1. Text 2. CSV");
        string choice = Console.ReadLine();
        
        string filename = choice == "1" ? "expenses.txt" : "expenses.csv";
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Description,Amount,Category");
            foreach (var exp in expenses)
            {
                writer.WriteLine($"{exp.Description},{exp.Amount},{exp.Category}");
            }
        }
        Console.WriteLine($"Expenses exported to {filename}");
    }

    static void CheckTotalSpent()
    {
        double total = expenses.Sum(e => e.Amount);
        Console.WriteLine($"Total Amount Spent: ${total}");
    }

    static void CheckExpensesByCategory()
    {
        var categories = expenses.Select(e => e.Category).Distinct().ToList();
        if (!categories.Any())
        {
            Console.WriteLine("No categories available.");
            return;
        }

        Console.WriteLine("Available Categories:");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i]}");
        }
        
        Console.Write("Choose a category: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= categories.Count)
        {
            string selectedCategory = categories[index - 1];
            var filteredExpenses = expenses.Where(e => e.Category == selectedCategory).ToList();
            
            Console.WriteLine($"\nExpenses in {selectedCategory}:");
            foreach (var exp in filteredExpenses)
            {
                Console.WriteLine($"{exp.Description} - ${exp.Amount}");
            }
            Console.WriteLine($"Total Spent in {selectedCategory}: ${filteredExpenses.Sum(e => e.Amount)}");
        }
        else
        {
            Console.WriteLine("Invalid selection!");
        }
    }
}
