﻿// <auto-generated />
using M06Habits.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace M06Habits.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("M06Habits.Models.ApplicationResponse", b =>
                {
                    b.Property<int>("DataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("category")
                        .HasColumnType("TEXT");

                    b.Property<bool>("completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("due_date")
                        .HasColumnType("TEXT");

                    b.Property<int>("quadrant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("task")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DataId");

                    b.HasIndex("CategoryID");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            DataId = 1,
                            CategoryID = 1,
                            completed = false,
                            due_date = "Feb. 28,2000",
                            quadrant = 4,
                            task = "Example Task"
                        },
                        new
                        {
                            DataId = 2,
                            CategoryID = 2,
                            completed = true,
                            due_date = "Feb. 27,2000",
                            quadrant = 3,
                            task = "2nd Example Task"
                        },
                        new
                        {
                            DataId = 3,
                            CategoryID = 3,
                            completed = false,
                            due_date = "Feb. 26,2000",
                            quadrant = 2,
                            task = "3rd Example Task"
                        });
                });

            modelBuilder.Entity("M06Habits.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Home"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "School"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Work"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Church"
                        });
                });

            modelBuilder.Entity("M06Habits.Models.ApplicationResponse", b =>
                {
                    b.HasOne("M06Habits.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
