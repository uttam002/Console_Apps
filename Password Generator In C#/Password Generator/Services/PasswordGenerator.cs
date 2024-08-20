using PasswordGeneratorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorApp.Services
{
    public class PasswordGenerator
    {
        private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string Special = "!@#$%^&*()-_=+<>?";
        private const string SimilarCharacters = "O0Il1";

        public string GeneratePassword(PasswordOptions options)
        {
            StringBuilder characterSet = new StringBuilder();

            if (options.IncludeLowercase)
                characterSet.Append(Lowercase);
            if (options.IncludeUppercase)
                characterSet.Append(Uppercase);
            if (options.IncludeDigits)
                characterSet.Append(Digits);
            if (options.IncludeSpecial)
                characterSet.Append(Special);

            if (options.ExcludeSimilar)
            {
                foreach (char c in SimilarCharacters)
                {
                    characterSet.Replace(c.ToString(), string.Empty);
                }
            }

            if (characterSet.Length == 0)
                throw new ArgumentException("No character types selected. Please select at least one character type.");

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < options.Length; i++)
            {
                password.Append(characterSet[random.Next(characterSet.Length)]);
            }

            if (options.EnforceComplexity)
            {
                EnsureComplexity(password, options);
            }

            return password.ToString();
        }

        private void EnsureComplexity(StringBuilder password, PasswordOptions options)
        {
            Random random = new Random();

            if (options.IncludeLowercase && !ContainsCharacter(password, Lowercase))
            {
                password[random.Next(password.Length)] = Lowercase[random.Next(Lowercase.Length)];
            }
            if (options.IncludeUppercase && !ContainsCharacter(password, Uppercase))
            {
                password[random.Next(password.Length)] = Uppercase[random.Next(Uppercase.Length)];
            }
            if (options.IncludeDigits && !ContainsCharacter(password, Digits))
            {
                password[random.Next(password.Length)] = Digits[random.Next(Digits.Length)];
            }
            if (options.IncludeSpecial && !ContainsCharacter(password, Special))
            {
                password[random.Next(password.Length)] = Special[random.Next(Special.Length)];
            }
        }

        private bool ContainsCharacter(StringBuilder password, string characterSet)
        {
            foreach (char c in characterSet)
            {
                if (password.ToString().Contains(c))
                    return true;
            }
            return false;
        }
    }
}
