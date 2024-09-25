using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_manager_OOP
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nWelcome to Task Management System 'Ibrahim Saber Gaber'");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Save and Exit");
                Console.Write("Choose an option: ");
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
                        MarkTaskAsCompleted();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        SaveTasksToFile();
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        public void AddTask()
        {
            bool addMoreTasks = true;
            while (addMoreTasks)
            {
                Console.Clear();
                Console.Write("Enter task title: ");
                string title = Console.ReadLine();
                Console.Write("Enter task description: ");
                string description = Console.ReadLine();

                tasks.Add(new Task(title, description));

                Console.WriteLine("\nDo you want to add another task? (y/n): ");
                string response = Console.ReadLine().ToLower();
                if (response != "y")
                {
                    addMoreTasks = false;
                }
            }
            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
        }

        public void ViewTasks()
        {
            Console.Clear();
            Console.WriteLine("\nTasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
        }

        public void MarkTaskAsCompleted()
        {
            Console.Clear();
            ViewTasks();
            Console.Write("Enter the task number to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber <= tasks.Count)
            {
                tasks[taskNumber - 1].IsCompleted = true;
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
        }

        public void DeleteTask()
        {
            Console.Clear();
            ViewTasks();
            Console.Write("Enter the task number to delete: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(taskNumber - 1);
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
        }

        public void SaveTasksToFile()
        {
            using (StreamWriter sw = new StreamWriter("tasks.txt"))
            {
                foreach (Task task in tasks)
                {
                    sw.WriteLine($"{task.Title}|{task.Description}|{task.IsCompleted}");
                }
            }
        }

        public void LoadTasksFromFile()
        {
           if (File.Exists("tasks.txt"))
            {
                string[] lines = File.ReadAllLines("tasks.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    Task task = new Task(parts[0], parts[1])
                    {
                        IsCompleted = bool.Parse(parts[2])
                    };
                    Task task = new Task(parts[0], parts[1]);
                    task.IsCompleted = bool.Parse(parts[2]);

                    tasks.Add(task);
                }
            }
        }

    }
}
