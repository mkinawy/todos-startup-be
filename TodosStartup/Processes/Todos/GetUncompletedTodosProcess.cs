using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodosStartup.Entities;

namespace TodosStartup.Processes.Todos
{
    public class GetUncompletedTodosProcess
    {
        public class Request : IRequest<List<Response>> { }

        public class Response
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }

        public class Handler : IRequestHandler<Request, List<Response>>
        {
            private readonly IMapper _mapper;

            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public async Task<List<Response>> Handle(Request request, CancellationToken cancellationToken)
            {
                var entities = TodoEntity.AllTodos.Where(t => !t.Completed);
                var resp = _mapper.Map<List<Response>>(entities);
                return resp;
            }
        }

        public class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<TodoEntity, Response>();
            }
        }
    }
}