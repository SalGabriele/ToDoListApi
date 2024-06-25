using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using ToDoListApi1.Models;

namespace ToDoListApi1.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
