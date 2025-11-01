using MediatR;
using CQRS.Domain;

namespace CQRS.Application.Queries
{
    public record GetAllTasksQuery() : IRequest<IEnumerable<TaskItem>>;
}
