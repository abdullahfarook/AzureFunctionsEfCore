using System;
using Microsoft.EntityFrameworkCore;

namespace Qx.Services
{
    public class Todo
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Todo> Todos { get; set; }
    }
}
