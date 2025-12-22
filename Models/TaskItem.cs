using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; } // To Do, In Progress, Completed

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
    }
}
