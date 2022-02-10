using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace M06Habits.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int DataId { get; set; }
        [Required]
        public string task { get; set; }

        public string due_date { get; set; }

        [Required]
        [Range(1,4)]
        public int quadrant { get; set; }

        public string category { get; set; }

        public bool completed { get; set; }

        // Foreign Key

        [Required]
         public int CategoryID { get; set; }
         public Category Category { get; set; }


    }
}