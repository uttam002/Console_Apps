using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your full name:");
        string fullName = Console.ReadLine();

        Console.WriteLine("Enter the desired length of the short name:");
        int lengthOfShortName;
        while (!int.TryParse(Console.ReadLine(), out lengthOfShortName) || lengthOfShortName <= 0)
        {
            Console.WriteLine("Please enter a valid positive number for the length:");
        }

        // Split the full name into parts
        string[] nameParts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (nameParts.Length < 2)
        {
            Console.WriteLine("Please enter at least a first name and a last name.");
            return;
        }

        // Generate different short name options
        string shortName1 = $"{nameParts[0][0]}. {string.Join(" ", nameParts.Skip(1).Select(n => n[0] + "."))}";
        string shortName2 = $"{nameParts[0]} {nameParts[1][0]}. {string.Join(" ", nameParts.Skip(2))}";
        string shortName3 = $"{nameParts[0]} {nameParts[^1]}";

        // Truncate the names if necessary
        shortName1 = shortName1.Length > lengthOfShortName ? shortName1.Substring(0, lengthOfShortName).TrimEnd('.') + "..." : shortName1;
        shortName2 = shortName2.Length > lengthOfShortName ? shortName2.Substring(0, lengthOfShortName).TrimEnd('.') + "..." : shortName2;
        shortName3 = shortName3.Length > lengthOfShortName ? shortName3.Substring(0, lengthOfShortName).TrimEnd('.') + "..." : shortName3;

        // Output the options
        Console.WriteLine("\nHere are your short name options:");
        Console.WriteLine($"Short Name 1: {shortName1}");
        Console.WriteLine($"Short Name 2: {shortName2}");
        Console.WriteLine($"Short Name 3: {shortName3}");
    }
}
 