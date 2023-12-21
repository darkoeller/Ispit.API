namespace Ispit.Data.Models;

public class TodoListContext : DbContext
{
   public TodoListContext()
   {
   }

   public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
   {
   }

   public DbSet<TodoList> TodoLists { get; set; } = null!;

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      base.OnConfiguring(optionsBuilder);
      if (!optionsBuilder.IsConfigured)
      {
         optionsBuilder.UseSqlServer(
            "Data Source=DESKTOP-DBUENO3;Initial Catalog=TodoListDb;Integrated Security=True;Encrypt=False; Trust Server Certificate=True");
      }
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
      //modelBuilder.Entity<TodoList>().HasData(
      //   new TodoList { Id = 1, Title = "Trgovina", Description = "Nađi večeru", IsCompleted = false },
      //   new TodoList { Id = 2, Title = "Bijeg", Description = "Kako pobjeći bez traga", IsCompleted = false },
      //   new TodoList { Id = 3, Title = "U suton", Description = "Što raditi poslije spavanja", IsCompleted = false },
      //   new TodoList { Id = 4, Title = "Snovi", Description = "Zaboraviti noćne more", IsCompleted = false }
      //);
   }
}