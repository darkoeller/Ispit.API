using Ispit.Data.Models;

namespace Ispit.Data.Interfaces;

public interface ITodoListRepository
{
   IEnumerable<TodoList> GetAll();

   TodoList GetTodoListById(int id);

   TodoList InsertTodoList(TodoList movie);

   TodoList UpdateTodoList(TodoList movie);

   TodoList DeleteTodoList(int id);

}