using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List;

namespace To_Do_List.Services
{
    public class TaskService
    {
        public List<Task> Tasks { get; set; } = new List<Task>();

        public void AddTask()
        {
            Console.WriteLine("Enter the task description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the task category:");
            string category = Console.ReadLine();

            Console.WriteLine("Enter the due date (dd/MM/yyyy) or leave empty for no due date:");
            DateTime? dueDate = null;
            string dateInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dateInput))
            {
                dueDate = DateTime.ParseExact(dateInput, "dd/MM/yyyy", null);
            }

            Tasks.Add(new Task(description, category, dueDate));
            Console.WriteLine("Task added.");
        }

        public void RemoveTask()
        {
            Console.WriteLine("Enter the task number to remove:");
            int taskNumber = int.Parse(Console.ReadLine());
            if (taskNumber > 0 && taskNumber <= Tasks.Count)
            {
                Tasks.RemoveAt(taskNumber - 1);
                Console.WriteLine("Task removed.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        public void ListTasks()
        {
            Console.WriteLine("To-Do List:");
            for (int i = 0; i < Tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Tasks[i]}");
            }
        }

        public void CompleteTask()
        {
            Console.WriteLine("Enter the task number to mark as complete:");
            int taskNumber = int.Parse(Console.ReadLine());
            if (taskNumber > 0 && taskNumber <= Tasks.Count)
            {
                Tasks[taskNumber - 1].IsComplete = true;
                Console.WriteLine("Task marked as complete.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        public void SearchTasks()
        {
            Console.WriteLine("Enter a search keyword or date (dd/MM/yyyy):");
            string searchTerm = Console.ReadLine().ToLower();

            DateTime? searchDate = null;
            if (DateTime.TryParseExact(searchTerm, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
            {
                searchDate = parsedDate;
            }

            Console.WriteLine("Search Results:");
            foreach (var task in Tasks)
            {
                bool matchesKeyword = task.Description.ToLower().Contains(searchTerm) || task.Category.ToLower().Contains(searchTerm);
                bool matchesDate = task.DueDate.HasValue && searchDate.HasValue && task.DueDate.Value.Date == searchDate.Value.Date;

                if (matchesKeyword || matchesDate)
                {
                    Console.WriteLine(task);
                }
            }
        }
    }
}
