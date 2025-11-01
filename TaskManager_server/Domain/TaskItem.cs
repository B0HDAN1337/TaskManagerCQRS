namespace TaskManager_server.Domain
{
    public class TaskItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; private set; }
        public bool IsCompleted { get; private set; }

        public TaskItem(string title)
        {
            Title = title;
        }

        public void Complete() => IsCompleted = true;
    }
}