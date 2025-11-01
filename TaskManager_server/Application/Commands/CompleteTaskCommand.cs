using MediatR;

namespace TaskManager_server.Application.Commands
{
    public record CompleteTaskCommand(Guid Id) : IRequest<bool>;
}
