using System;
using System.IO;

namespace TodoListApp
{
    class Program
    {
        // File where tasks will be stored
        private static readonly string filePath = "tasks.txt";

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                DisplayMenu();
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;

                    case "2":
                        ViewTasks();
                        break;

                    case "3":
                        Console.WriteLine("Exiting program. Goodbye!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please enter 1, 2, or 3.");
                        break;
                }

                Console.WriteLine(); // spacing
            }
        }

        // Displays the main menu
        static void DisplayMenu()
        {
            Console.WriteLine("===== TODO LIST MENU =====");
            Console.WriteLine("1. Add a New Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Exit");
            Console.WriteLine("==========================");
        }

        // Adds a new task to the file
        static void AddTask()
        {
            Console.Write("Enter a new task: ");
            string task = Console.ReadLine();

            try
            {
                File.AppendAllText(filePath, task + Environment.NewLine);
                Console.WriteLine("Task added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving task: " + ex.Message);
            }
        }

        // Reads and displays all tasks from the file
        static void ViewTasks()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No tasks found. The task file does not exist yet.");
                    return;
                }

                string[] tasks = File.ReadAllLines(filePath);

                if (tasks.Length == 0)
                {
                    Console.WriteLine("The task list is empty.");
                    return;
                }

                Console.WriteLine("===== SAVED TASKS =====");
                foreach (string task in tasks)
                {
                    Console.WriteLine("- " + task);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading tasks: " + ex.Message);
            }
        }
    }
}
