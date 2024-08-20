using System;
using System.IO;

namespace PasswordGeneratorApp.Utils
{
    public static class FileManager
    {
        public static void SavePassword(string password)
        {
            string path = "passwords.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Now}: {password}");
            }
            Console.WriteLine($"Password saved to {path}");
        }
    }
}
