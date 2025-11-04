using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSphere.API.DTOs.TaskItem;
using TaskSphere.API.Mappers;
using TaskSphere.API.Model;
using TaskSphere.API.Services.Interfaces;

namespace TaskSphere.API.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/taskitem")]
  public class TaskItemController : ControllerBase
  {
    private readonly ITaskItemService _taskItemService;
    private readonly IUserContextService _userContextService;

    public TaskItemController(
      ITaskItemService taskItemService,
      IUserContextService userContextService)
    {
      _taskItemService = taskItemService;
      _userContextService = userContextService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAllTasks()
    {
      var userId = _userContextService.GetUserId();
      var tasks = await _taskItemService.GetTasksAsync(userId);
      var taskDtos = tasks.Select(t => t.ToTaskItemDto());

      return Ok(taskDtos);
    }

    [HttpGet("{taskId:int}")]
    public async Task<ActionResult<TaskItemDto>> GetTaskById(int taskId)
    {
      try
      {
        var userId = _userContextService.GetUserId();
        var task = await _taskItemService.GetTaskByIdAsync(userId, taskId);

        if (task == null)
          return NotFound("Task not found.");

        return Ok(task.ToTaskItemDto());
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex.Message);
      }
    }

    [HttpPost]
    public async Task<ActionResult<TaskItemDto>> CreateTask([FromBody] TaskItemDto dto)
    {
      try
      {
        var userId = _userContextService.GetUserId();
        var task = dto.ToTaskItem(userId);
        var created = await _taskItemService.CreateTaskAsync(task);

        return CreatedAtAction(nameof(GetTaskById), new { taskId = created.Id }, created.ToTaskItemDto());
      }
      catch (ArgumentException ex)
      {
        return BadRequest(ex.Message);
      }
      catch (InvalidOperationException ex)
      {
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode(500, "An error occurred while creating the task. " + ex.Message);
      }
    }

    [HttpPut("{taskId:int}")]
    public async Task<ActionResult<TaskItemDto>> UpdateTask(int taskId, [FromBody] TaskItemDto dto)
    {
      try
      {
        var userId = _userContextService.GetUserId();
        var taskToUpdate = dto.ToTaskItem(userId);
        taskToUpdate.Id = taskId;

        var updated = await _taskItemService.UpdateTaskAsync(taskToUpdate);
        return Ok(updated.ToTaskItemDto());
      }
      catch (KeyNotFoundException ex)
      {
        return NotFound(ex.Message);
      }
      catch (ArgumentException ex)
      {
        return BadRequest(ex.Message);
      }
      catch (InvalidOperationException ex)
      {
        return BadRequest(ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode(500, "An error occurred while updating the task. " + ex.Message);
      }
    }

    [HttpDelete("{taskId:int}")]
    public async Task<IActionResult> DeleteTask(int taskId)
    {
      try
      {
        var userId = _userContextService.GetUserId();
        var deleted = await _taskItemService.DeleteTaskAsync(userId, taskId);

        if (!deleted)
          return NotFound("Task not found or already deleted.");

        return NoContent();
      }
      catch (KeyNotFoundException ex)
      {
        return NotFound(ex.Message);
      }
      catch (Exception ex)
      {
        return StatusCode(500, "An error occurred while deleting the task. " + ex.Message);
      }
    }
  }
}
