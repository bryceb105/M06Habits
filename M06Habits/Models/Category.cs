﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M06Habits.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

    }
}
