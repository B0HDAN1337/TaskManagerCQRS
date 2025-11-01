using MediatR;
using TaskManager_server.Domain;
using TaskManager_server.Infrastructure;

namespace TaskManager_server.Application.Queries
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItem>>
    {
        private readonly TaskRepository _repo;
        public GetAllTasksQueryHandler(TaskRepository repo) => _repo = repo;

        public Task<IEnumerable<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repo.GetAll());
        }
    }
}
