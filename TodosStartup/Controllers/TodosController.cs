using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodosStartup.Processes.Todos;

namespace TodosStartup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUncompletedTodos([FromQuery] GetUncompletedTodosProcess.Request request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedTodos([FromQuery] GetCompletedTodosProcess.Request request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] AddTodoProcess.Request request, CancellationToken cancellationToken)
        {
            var success = await _mediator.Send(request, cancellationToken);
            if (success) return Ok();
            return BadRequest();
        }

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> CompleteTodo([FromRoute] CompleteTodoProcess.Request request, CancellationToken cancellationToken)
        {
            var success = await _mediator.Send(request, cancellationToken);
            if (success) return Ok();
            return BadRequest();
        }
    }
}
