using MediatR;
using TaskManager_server.Domain;
using TaskManager_server.Infrastructure;

namespace TaskManager_server.Application.Commands
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, TaskItem>
    {
        private readonly TaskRepository _repository;
        public AddTaskCommandHandler(TaskRepository repository) => _repository = repository;

        public Task<TaskItem> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem(request.Title);
            _repository.Add(task);
            return Task.FromResult(task);
        }
    }

    public class CompleteTaskCommandHandler : IRequestHandler<CompleteTaskCommand, bool>
    {
        private readonly TaskRepository _repository;
        public CompleteTaskCommandHandler(TaskRepository repository) => _repository = repository;

        public Task<bool> Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _repository.GetById(request.Id);
            if (task == null) return Task.FromResult(false);
            task.Complete();
            return Task.FromResult(true);
        }
    }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly TaskRepository _repository;
        public DeleteTaskCommandHandler(TaskRepository repository) => _repository = repository;

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _repository.GetById(request.Id);
            if (task == null)
            {
                return false;
            }

            _repository.Delete(request.Id);
            return true;
           
        }
    }
}
