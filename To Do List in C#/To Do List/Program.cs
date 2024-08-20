using System;
using System.Collections.Generic;
using To_Do_List.Services;
using To_Do_List;

namespace To_Do_List
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskService taskService = new TaskService();
            FileService fileService = new FileService("tasks.json");

            taskService.Tasks = fileService.LoadTasks();

            string command = "";
            while (command != "exit")
            {
                Console.WriteLine("Enter a command (add, remove, list, complete, save, search, exit):");
                command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "add":
                        taskService.AddTask();
                        break;
                    case "remove":
                        taskService.RemoveTask();
                        break;
                    case "list":
                        taskService.ListTasks();
                        break;
                    case "complete":
                        taskService.CompleteTask();
                        break;
                    case "save":
                        fileService.SaveTasks(taskService.Tasks);
                        break;
                    case "search":
                        taskService.SearchTasks();
                        break;
                    case "exit":
                        fileService.SaveTasks(taskService.Tasks);
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }
}
