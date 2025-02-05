using System;

namespace TaskManagerAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public string? Priority { get; set; } // Low, Medium, High
        public bool IsCompleted { get; set; }
    }
}
