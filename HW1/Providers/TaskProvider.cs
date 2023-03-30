namespace HW1.Providers
{
    public class TaskProvider
    {
        private static TaskProvider _instance;
        private static readonly object _lock = new object();
        private readonly List<Models.MyTask> _tasks;

        private TaskProvider()
        {
            _tasks = new List<Models.MyTask>();
        }

        public static TaskProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TaskProvider();
                        }
                    }
                }

                return _instance;
            }
        }

        public List<Models.MyTask> GetAllTasks()
        {
            return _tasks;
        }

        public Models.MyTask GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(Models.MyTask task)
        {
            int newId = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
            task.GetType().GetProperty("Id").SetValue(task, newId);
            _tasks.Add(task);
        }

        public void UpdateTask(int id, Models.MyTask task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == id);

            if (existingTask != null)
            {
                existingTask.Name = task.Name;
                existingTask.Description = task.Description;
                existingTask.IsComplete = task.IsComplete;
            }
        }

        public void DeleteTask(int id)
        {
            var taskToDelete = _tasks.FirstOrDefault(t => t.Id == id);

            if (taskToDelete != null)
            {
                _tasks.Remove(taskToDelete);
            }
        }
    }
}
