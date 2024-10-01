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
                        IsFinished = false,
                        GoalToFinish = DateTime.Parse("2021-09-01")
                    },
                    new Todo
                    {
                        Name = "MiawAWAW",
                        Category = "Cat",
                        Description = "A cat that meows a lot",
                        IsFinished = true,
                        GoalToFinish = DateTime.Parse("2022-09-01")
                    },
                    new Todo
                    {
                        Name = "DAYM",
                        Category = "Human",
                        Description = "A human that says daym",
                        IsFinished = false,
                        GoalToFinish = DateTime.Parse("2023-09-01")
                    },
                    new Todo
                    {
                        Name = "Holy sheeesh",
                        Category = "Human",
                        Description = "A human that says holy sheeesh",
                        IsFinished = true,
                        GoalToFinish = DateTime.Parse("2024-09-01")
                    },
                    new Todo
                    {
                        Name = "Rawrrrrr",
                        Category = "Dinosaur",
                        Description = "A dinosaur that says rawrrrrr",
                        IsFinished = false,
                        GoalToFinish = DateTime.Parse("2025-09-01")
                    },
                    new Todo
                    {
                        Name = "Rawrrrrr Miaw",
                        Category = "Fake Dinosaur",
                        Description = "A dinosaur that says rawrrrrr, but actually it is a cat",
                        IsFinished = false,
                        GoalToFinish = DateTime.Parse("2025-09-01")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
