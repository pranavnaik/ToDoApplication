using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApplication.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string TaskName { get; set; }

        [DisplayName("Description")]
        public string TaskDescription { get; set; }

        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime EnteredDate { get; set; }

        [DisplayName("Status")]
        public bool IsComplete { get; set; }

        [Required]
        public String AssignedTo { get; set; }
    }
}