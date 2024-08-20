using System;
using PasswordGeneratorApp.Models;
using PasswordGeneratorApp.Services;
using PasswordGeneratorApp.Utils;

namespace PasswordGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordOptions options = GetPasswordOptions();

            PasswordGenerator generator = new PasswordGenerator();
            string password = generator.GeneratePassword(options);

            Console.WriteLine($"Generated Password: {password}");

            string strength = PasswordStrengthChecker.AssessStrength(password);
            Console.WriteLine($"Password Strength: {strength}");

            FileManager.SavePassword(password);
        }

        static PasswordOptions GetPasswordOptions()
        {
            PasswordOptions options = new PasswordOptions();

            Console.WriteLine("Enter the length of the password:");
            options.Length = int.Parse(Console.ReadLine());

            Console.WriteLine("Include lowercase letters? (y/n):");
            options.IncludeLowercase = Console.ReadLine().ToLower() == "y";

            Console.WriteLine("Include uppercase letters? (y/n):");
            options.IncludeUppercase = Console.ReadLine().ToLower() == "y";

            Console.WriteLine("Include digits? (y/n):");
            options.IncludeDigits = Console.ReadLine().ToLower() == "y";

            Console.WriteLine("Include special characters? (y/n):");
            options.IncludeSpecial = Console.ReadLine().ToLower() == "y";

            Console.WriteLine("Exclude similar characters (O, 0, I, l)? (y/n):");
            options.ExcludeSimilar = Console.ReadLine().ToLower() == "y";

            Console.WriteLine("Enforce complexity (include at least one of each selected type)? (y/n):");
            options.EnforceComplexity = Console.ReadLine().ToLower() == "y";

            return options;
        }
    }
}
