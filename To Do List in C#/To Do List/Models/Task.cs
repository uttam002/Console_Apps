using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    public class Task
    {
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsComplete { get; set; }

        public Task(string description, string category, DateTime? dueDate)
        {
            Description = description;
            Category = category;
            DueDate = dueDate;
            IsComplete = false;
        }

        public override string ToString()
        {
            string status = IsComplete ? "[X]" : "[ ]";
            string dueDate = DueDate.HasValue ? $"(Due: {DueDate.Value.ToShortDateString()})" : "";
            return $"{status} {Description} {dueDate} - Category: {Category}";
        }
    }
}
