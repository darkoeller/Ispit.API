using Ispit.Data.Interfaces;
using Ispit.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ispit.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class TodoListsController : ControllerBase
   {
      private readonly TodoListContext _context;
      private readonly ITodoListRepository _repository;
      public TodoListsController(ITodoListRepository repository, TodoListContext context)
      {
         _repository = repository;
         _context = context;
      }
      // GET: api/TodoLists
      [HttpGet]
      public ActionResult<IEnumerable<TodoList>> GetTodoList()
      {
         try
         {
            return Ok(_repository.GetAll());
         }
         catch (Exception)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
         }
      }
      // GET: api/TodoList/2
      [HttpGet("{id}")]
      public ActionResult<TodoList> GetTodoList(int id)
      {
         try
         {
            var result = _repository.GetTodoListById(id);

            if (result == null)
            {
               return NotFound();
            }

            return Ok(result);
         }
         catch (Exception)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
         }
      }
      // POST: api/TodoList
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPost]
      public ActionResult<TodoList> PostTodoList([FromBody] TodoList todolist)
      {
         try
         {
            if (!ModelState.IsValid)
            {
               return BadRequest(ModelState);
            }

            var createdTodoList = _repository.InsertTodoList(todolist);

            return CreatedAtAction(nameof(GetTodoList), new { id = createdTodoList.Id }, createdTodoList);
         }
         catch (Exception)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new todolist record");
         }
      }
      // PUT: api/TodoList/4
      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      [HttpPut("{id}")]
      public IActionResult PutMovie(int id, TodoList todoList)
      {
         try
         {
            if (id != todoList.Id)
            {
               return BadRequest("Movie Id missmatch!");
            }

            var listToDoToUpdate = _repository.GetTodoListById(id);
            if (listToDoToUpdate == null)
            {
               return NotFound($"Todolista with Id = {id} not found");
            }

            return Ok(_repository.UpdateTodoList(todoList));
         }
         catch (Exception)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error updating movie record");
         }
      }

      // DELETE: api/TodoList/5
      [HttpDelete("{id}")]
      public IActionResult DeleteTodoList(int id)
      {
         try
         {
            var todoList = _repository.GetTodoListById(id);
            if (todoList == null)
            {
               return NotFound($"TodoLista with Id = {id} not found");
            }

            return Ok(_repository.DeleteTodoList(id));
         }
         catch (Exception)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting movie record");
         }
      }


   }
}
