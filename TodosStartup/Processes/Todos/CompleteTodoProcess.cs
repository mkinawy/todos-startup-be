using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodosStartup.Entities;

namespace TodosStartup.Processes.Todos
{
    public class CompleteTodoProcess
    {
        public class Request : IRequest<bool>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Request, bool>
        {
            public async Task<bool> Handle(Request request, CancellationToken cancellationToken)
            {
                var todo = TodoEntity.AllTodos.SingleOrDefault(t => t.Id == request.Id);
                if (todo != null)
                {
                    todo.Completed = true;
                }

                return true;
            }
        }
    }
}