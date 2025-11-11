using MediatR;
using TaskManager_server.Domain;
using TaskManager_server.Infrastructure;

namespace TaskManager_server.Application.Commands
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, TaskItem>
    {
        private readonly TaskWriteRepository _writeRepository;
        private readonly TaskReadRepository _readRepository;
        public AddTaskCommandHandler(TaskWriteRepository writeRepository, TaskReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<TaskItem> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem(request.Title);
            await _writeRepository.AddAsync(task);
            await _readRepository.AddAsync(task);
            return task;
        }
    }

    public class CompleteTaskCommandHandler : IRequestHandler<CompleteTaskCommand, bool>
    {
        private readonly TaskWriteRepository _writeRepository;
        private readonly TaskReadRepository _readRepository;
        public CompleteTaskCommandHandler(TaskWriteRepository writeRepository, TaskReadRepository readRepository) 
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<bool> Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.CompleteAsync(request.Id);
            await _readRepository.CompleteAsync(request.Id);
            return true;
        }
    }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly TaskWriteRepository _writeRepository;
        private readonly TaskReadRepository _readRepository;
        public DeleteTaskCommandHandler(TaskWriteRepository writeRepository, TaskReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _writeRepository.DeleteAsync(request.Id);
            await _readRepository.DeleteAsync(request.Id);
            return true;
           
        }
    }
}
