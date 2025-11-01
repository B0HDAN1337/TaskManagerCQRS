using MediatR;
using TaskManager_server.Domain;

namespace TaskManager_server.Application.Commands
{
    public record AddTaskCommand(string Title) : IRequest<TaskItem>;
}
