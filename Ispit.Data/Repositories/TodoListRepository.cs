using Ispit.Data.Interfaces;
using Ispit.Data.Models;

namespace Ispit.Data.Repositories;

public class TodoListRepository : ITodoListRepository
{
   private readonly TodoListContext _context;
   public TodoListRepository(TodoListContext context)
   {
      _context = context;
   }
   public IEnumerable<TodoList> GetAll()
   {
      return _context.TodoLists.ToList();
   }

   public TodoList GetTodoListById(int id)
   {
      return _context.TodoLists.FirstOrDefault(f => f.Id == id);
   }

   public TodoList InsertTodoList(TodoList movie)
   {
      var result = _context.Add(movie);
      _context.SaveChanges();
      return result.Entity;
   }

   public TodoList UpdateTodoList(TodoList movie)
   {
      var result = _context.TodoLists.FirstOrDefault(m => m.Id == movie.Id);
      if (result != null)
      {
         result.Title = movie.Title;
         result.Description = movie.Description;
         result.IsCompleted = movie.IsCompleted;
         _context.SaveChanges();
         return result;
      }

      return null;
   }

   public TodoList DeleteTodoList(int id)
   {
      var result = _context.TodoLists.FirstOrDefault(m => m.Id == id);
      if (result != null)
      {
         _context.TodoLists.Remove(result);
         _context.SaveChanges();
         return result;
      }
      return null;
   }
}