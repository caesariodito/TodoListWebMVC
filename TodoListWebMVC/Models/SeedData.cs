using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoListWebMVC.Data;
using System;
using System.Linq;

namespace TodoListWebMVC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoListWebMVCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TodoListWebMVCContext>>()))
            {
                // Look for any movies.
                if (context.Todo.Any())
                {
                    return;   // DB has been seeded
                }
                context.Todo.AddRange( // The seeder
                    new Todo
                    {
                        Name = "Miaw",
                        Category = "Cat",
                        Description = "A cat that meows",
                        //CreatedAt = DateTime.Parse("2021-08-01"),
                        //EditedAt = DateTime.Parse("2021-08-01"),
                        IsFinished = false,
                    },
                    new Todo
                    {
                        Name = "MiawAWAW",
                        Category = "Cat",
                        Description = "A cat that meows a lot",
                        //CreatedAt = DateTime.Parse("2022-08-01"),
                        //EditedAt = DateTime.Parse("2022-08-01"),
                        IsFinished = true,
                    },
                    new Todo
                    {
                        Name = "DAYM",
                        Category = "Human",
                        Description = "A human that says daym",
                        //CreatedAt = DateTime.Parse("2023-08-01"),
                        //EditedAt = DateTime.Parse("2023-08-01"),
                        IsFinished = false,
                    },
                    new Todo
                    {
                        Name = "Holy sheeesh",
                        Category = "Human",
                        Description = "A human that says holy sheeesh",
                        //CreatedAt = DateTime.Parse("2024-08-01"),
                        //EditedAt = DateTime.Parse("2024-08-01"),
                        IsFinished = true,
                    },
                    new Todo
                    {
                        Name = "Rawrrrrr",
                        Category = "Dinosaur",
                        Description = "A dinosaur that says rawrrrrr",
                        //CreatedAt = DateTime.Parse("2025-08-01"),
                        //EditedAt = DateTime.Parse("2025-08-02"),
                        IsFinished = false,
                    },
                    new Todo
                    {
                        Name = "Rawrrrrr Miaw",
                        Category = "Fake Dinosaur",
                        Description = "A dinosaur that says rawrrrrr, but actually it is a cat",
                        //CreatedAt = DateTime.Parse("2025-08-01"),
                        //EditedAt = DateTime.Parse("2025-08-02"),
                        IsFinished = false,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
