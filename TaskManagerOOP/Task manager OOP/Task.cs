using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_manager_OOP
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string title , string description) 
        {
            Title = title;
            Description = description;
            IsCompleted = false;
        }


        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }


        public override string ToString()
        {
            string status = IsCompleted ? "Complete" : "Pending";
            return $"Task Title: {Title}  \nTask Description: {Description}  " +
                $"\nTask Status: {status}\n-------------------------------";
        }
    }
}
