using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M06Habits.Models
{
    public class DataContext : DbContext
    {
        // Constructor
        public DataContext (DbContextOptions <DataContext> options): base(options) 
        {
            //Leave Blank for now
        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category>Categories { get; set; }

        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
            );

            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    DataId = 1,
                    task = "Midterm",
                    due_date = "Feb 15, 2022",
                    quadrant = 1,
                    CategoryID = 2,
                    completed = false
                },
                new ApplicationResponse
                {
                    DataId = 2,
                    task = "Pickleball",
                    due_date = "Feb 20, 2022",
                    quadrant = 2,
                    CategoryID = 1,
                    completed = false
                },
                new ApplicationResponse
                {
                    DataId = 3,
                    task = "Interuption",
                    due_date = "Feb 26, 2022",
                    quadrant = 3,
                    CategoryID = 3,
                    completed = true
                },
                new ApplicationResponse
                {
                    DataId = 4,
                    task = "Check Insta",
                    due_date = "Feb 28, 2022",
                    quadrant = 4,
                    CategoryID = 1,
                    completed = false
                }
            );
        }
    }
}
