using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodosStartup.Entities;

namespace TodosStartup.Processes.Todos
{
    public class AddTodoProcess
    {
        public class Request : IRequest<bool>
        {
            public string Text { get; set; }
        }

        public class Handler : IRequestHandler<Request, bool>
        {
            public async Task<bool> Handle(Request request, CancellationToken cancellationToken)
            {
                var maxId = TodoEntity.AllTodos.Max(t => t.Id);

                var todo = new TodoEntity
                {
                    Id = maxId + 1,
                    Text = request.Text,
                    Completed = false
                };
                TodoEntity.AllTodos.Add(todo);

                return true;
            }
        }
    }
}