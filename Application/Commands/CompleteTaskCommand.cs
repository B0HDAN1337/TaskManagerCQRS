using MediatR;

namespace CQRS.Application.Commands
{
    public record CompleteTaskCommand(Guid Id) : IRequest<bool>;
}
