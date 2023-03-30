using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly List<Models.MyTask> _tasks = new List<Models.MyTask>();

        [HttpGet]
        public ActionResult<IEnumerable<Models.MyTask>> GetAllTasks()
        {
            return _tasks;
        }

        [HttpGet("{id}")]
        public ActionResult<Models.MyTask> GetTaskById(int id)
        {
            var task = _tasks.Find(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpPost]
        public ActionResult<Task> AddTask(Models.MyTask task)
        {
            task.Id = _tasks.Count + 1;
            _tasks.Add(task);

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Models.MyTask task)
        {
            var existingTask = _tasks.Find(t => t.Id == id);

            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.Name = task.Name;
            existingTask.Description = task.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var taskToDelete = _tasks.Find(t => t.Id == id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            _tasks.Remove(taskToDelete);

            return NoContent();
        }
    }
}
