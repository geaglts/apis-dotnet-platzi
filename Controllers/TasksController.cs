using Microsoft.AspNetCore.Mvc;
using first_api.Models;

namespace first_api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TasksController : ControllerBase
{
    private static int TaskId = 0;
    private readonly ILogger<TasksController> _logger;

    private static List<TaskModel> TaskList = new List<TaskModel>();

    public TasksController(ILogger<TasksController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("All")]
    public IEnumerable<TaskModel> Get()
    {
        return TaskList;
    }

    [HttpPost]
    public IActionResult NewNode(TaskModel task)
    {
        task.Id = TaskId;
        TaskList.Add(task);
        TaskId++;

        return Created("uri", new { message = "Tarea creada correctamente" });
    }

    [HttpDelete("{taskId}")]
    public IActionResult DeleteOne(int taskId)
    {
        int TaskIndex = TaskList.FindIndex(task => task.Id == taskId);
        if (TaskIndex != -1)
        {
            TaskList.RemoveAt(TaskIndex);
            return Ok(new { message = "Eliminado correctamente" });
        }
        return NotFound(new { message = "No encontrado" });
    }
}