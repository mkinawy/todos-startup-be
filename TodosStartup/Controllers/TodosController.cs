using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodosStartup.Models;

namespace TodosStartup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private static List<Todo> AllTodos = new List<Todo>
        {
            new Todo {Id = 1, Text = "test 111"},
            new Todo {Id = 2, Text = "test 222"},
            new Todo {Id = 3, Text = "test 333"},
            new Todo {Id = 4, Text = "test 444", Completed = true},
            new Todo {Id = 5, Text = "test 555"},
        };

        [HttpGet]
        public IActionResult GetAllTodos()
        {
            var nonCompletedTodos = AllTodos.Where(t => !t.Completed);
            return Ok(nonCompletedTodos);
        }

        [HttpPost]
        public IActionResult AddTodo(Todo todo)
        {
            var maxId = AllTodos.Max(t => t.Id);
            todo.Id = maxId + 1;

            AllTodos.Add(todo);
            return Ok();
        }

        [HttpPost("{id}/complete")]
        public IActionResult CompleteTodo(int id)
        {
            var todo = AllTodos.SingleOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.Completed = true;
            }

            return Ok();
        }
    }
}
