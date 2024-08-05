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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
               .Property<DateTime>("CreatedAt");
            modelBuilder.Entity<Todo>()
               .Property<DateTime>("EditedAt");
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                    entry.Property("EditedAt").CurrentValue = DateTime.UtcNow;
                } else if (entry.State == EntityState.Modified)
                {
                    entry.Property("EditedAt").CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {

            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                    entry.Property("EditedAt").CurrentValue = DateTime.Now;
                } else if (entry.State == EntityState.Modified)
                {
                    entry.Property("EditedAt").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
