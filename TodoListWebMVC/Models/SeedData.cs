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
                        CreatedAt = DateTime.Parse("2021-08-01"),
                        EditedAt = DateTime.Parse("2021-08-01"),
                    },
                    new Todo
                    {
                        Name = "MiawAWAW",
                        CreatedAt = DateTime.Parse("2022-08-01"),
                        EditedAt = DateTime.Parse("2022-08-01"),
                    },
                    new Todo
                    {
                        Name = "DAYM",
                        CreatedAt = DateTime.Parse("2023-08-01"),
                        EditedAt = DateTime.Parse("2023-08-01"),
                    },
                    new Todo
                    {
                        Name = "Holy sheeesh",
                        CreatedAt = DateTime.Parse("2024-08-01"),
                        EditedAt = DateTime.Parse("2024-08-01"),
                    },
                    new Todo
                    {
                        Name = "Rawrrrrr",
                        CreatedAt = DateTime.Parse("2025-08-01"),
                        EditedAt = DateTime.Parse("2025-08-02"),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
