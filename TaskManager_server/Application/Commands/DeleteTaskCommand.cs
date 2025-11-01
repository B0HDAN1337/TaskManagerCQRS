using MediatR;

namespace TaskManager_server.Application.Commands
{
    public record DeleteTaskCommand(Guid Id) : IRequest<bool>;
}
