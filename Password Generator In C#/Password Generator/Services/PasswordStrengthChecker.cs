using System;
using System.Linq;

namespace PasswordGeneratorApp.Services
{
    public static class PasswordStrengthChecker
    {
        public static string AssessStrength(string password)
        {
            int score = 0;

            if (password.Length >= 8) score++;
            if (password.Any(char.IsLower)) score++;
            if (password.Any(char.IsUpper)) score++;
            if (password.Any(char.IsDigit)) score++;
            if (password.Any(c => "!@#$%^&*()-_=+<>?".Contains(c))) score++;

            return score switch
            {
                5 => "Very Strong",
                4 => "Strong",
                3 => "Moderate",
                2 => "Weak",
                _ => "Very Weak",
            };
        }
    }
}
