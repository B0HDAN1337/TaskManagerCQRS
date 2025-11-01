using MediatR;
using TaskManager_server.Domain;

namespace TaskManager_server.Application.Queries
{
    public record GetAllTasksQuery() : IRequest<IEnumerable<TaskItem>>;
}
