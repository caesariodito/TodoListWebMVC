using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListWebMVC.Models;

namespace TodoListWebMVC.Data
{
    public class TodoListWebMVCContext : DbContext
    {
        public TodoListWebMVCContext (DbContextOptions<TodoListWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<TodoListWebMVC.Models.Todo> Todo { get; set; } = default!;
    }
}
