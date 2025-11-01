using MediatR;
using CQRS.Domain;

namespace CQRS.Application.Commands
{
    public record AddTaskCommand(string Title) : IRequest<TaskItem>;
}
