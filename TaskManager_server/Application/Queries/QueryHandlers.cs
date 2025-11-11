using MediatR;
using TaskManager_server.Domain;
using TaskManager_server.Infrastructure;

namespace TaskManager_server.Application.Queries
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItem>>
    {
        private readonly TaskReadRepository _readRepository;
        public GetAllTasksQueryHandler(TaskReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<IEnumerable<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetAllAsync();
        }
    }
}
