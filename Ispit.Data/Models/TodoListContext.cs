using Microsoft.EntityFrameworkCore;

namespace Ispit.Data.Models;

public class TodoListContext : DbContext
{
   public TodoListContext()
   {

   }

   public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
   {

   }

   public DbSet<TodoList> TodoLists { get; set; }
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      base.OnConfiguring(optionsBuilder);
      if (!optionsBuilder.IsConfigured)
      {
         optionsBuilder.UseSqlServer("Data Source=DESKTOP-DBUENO3;Initial Catalog=TodoListDb;Integrated Security=True;Encrypt=False; Trust Server Certificate=True");
      }
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
      //modelBuilder.Entity<TodoList>().HasData(
      //);
   }
}