using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace To_Do_List.Services
{
    public class FileService
    {
        private readonly string filePath;

        public FileService(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveTasks(List<Task> tasks)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(filePath, json);
            Console.WriteLine("Tasks saved.");
        }

        public List<Task> LoadTasks()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Task>>(json);
            }
            else
            {
                return new List<Task>();
            }
        }
    }
}

