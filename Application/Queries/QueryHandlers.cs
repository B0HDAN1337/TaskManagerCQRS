using MediatR;
using CQRS.Domain;
using CQRS.Infrastructure;

namespace CQRS.Application.Queries
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
