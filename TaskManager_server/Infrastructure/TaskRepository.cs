using Microsoft.VisualBasic;
using TaskManager_server.Domain;

namespace TaskManager_server.Infrastructure
{
    public class TaskRepository
    {
        private readonly List<TaskItem> _tasks = new();

        public void Add(TaskItem task) => _tasks.Add(task);
        public IEnumerable<TaskItem> GetAll() => _tasks;
        public TaskItem? GetById(Guid id) => _tasks.FirstOrDefault(t => t.Id == id);
        public bool Delete(Guid id) => _tasks.Remove(_tasks.FirstOrDefault(t => t.Id == id));
    }
}
