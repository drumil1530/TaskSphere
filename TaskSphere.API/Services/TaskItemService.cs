using Microsoft.EntityFrameworkCore;
using TaskSphere.API.Model;
using TaskSphere.API.Repositories.Interfaces;
using TaskSphere.API.Services.Interfaces;

namespace TaskSphere.API.Services
{
  public class TaskItemService : ITaskItemService
  {
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly ICategoryRepository _categoryRepository;

    public TaskItemService(
      ITaskItemRepository taskItemRepository,
      ICategoryRepository categoryRepository)
    {
      _taskItemRepository = taskItemRepository;
      _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<TaskItem>> GetTasksAsync(int userId)
    {
      try
      {
        return await _taskItemRepository.GetTasksAsync(userId);
      }
      catch (Exception ex)
      {
        // Log error if you have a logger later
        throw new InvalidOperationException("Failed to fetch tasks.", ex);
      }
    }

    public async Task<TaskItem?> GetTaskByIdAsync(int userId, int taskId)
    {
      try
      {
        TaskItem? task = await _taskItemRepository.GetTaskByIdAsync(userId, taskId);
        if (task == null)
          throw new KeyNotFoundException("Task not found.");

        return task;
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException("Failed to fetch task.", ex);
      }
    }

    public async Task<TaskItem> CreateTaskAsync(TaskItem task)
    {
      try
      {
        // Basic validations
        if (string.IsNullOrWhiteSpace(task.Title))
          throw new ArgumentException("Task title is required.");

        if (task.StartTime > task.DueTime)
          throw new ArgumentException("Start time cannot be after due time.");

        // Validate category (if provided)
        if (task.CategoryId.HasValue)
        {
          bool exists = await _categoryRepository.ExistsForUserAsync(task.CategoryId.Value, task.UserId);
          if (!exists)
            throw new InvalidOperationException("Invalid category for this user.");
        }

        return await _taskItemRepository.CreateTaskAsync(task);
      }
      catch (DbUpdateException dbEx)
      {
        throw new InvalidOperationException("Database update failed while creating task.", dbEx);
      }
      catch (InvalidOperationException)
      {
        // Preserve specific validation messages
        throw;
      }
      catch (ArgumentException)
      {
        throw;
      }
      catch (KeyNotFoundException)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException("Failed to create task.", ex);
      }
    }

    public async Task<TaskItem> UpdateTaskAsync(TaskItem task)
    {
      try
      {
        // Ensure the task exists before update
        TaskItem? existing = await _taskItemRepository.GetTaskByIdAsync(task.UserId, task.Id);
        if (existing == null)
          throw new KeyNotFoundException("Task not found for update.");

        // Validation logic
        if (task.StartTime > task.DueTime)
          throw new ArgumentException("Start time cannot be after due time.");

        // Category validation
        if (task.CategoryId.HasValue)
        {
          bool exists = await _categoryRepository.ExistsForUserAsync(task.CategoryId.Value, task.UserId);
          if (!exists)
            throw new InvalidOperationException("Invalid category for this user.");
        }

        return await _taskItemRepository.UpdateTaskAsync(task);
      }
      catch (DbUpdateException dbEx)
      {
        throw new InvalidOperationException("Database update failed while updating task.", dbEx);
      }
      catch (InvalidOperationException)
      {
        // Preserve specific validation messages
        throw;
      }
      catch (ArgumentException)
      {
        throw;
      }
      catch (KeyNotFoundException)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException("Failed to update task.", ex);
      }
    }

    public async Task<bool> DeleteTaskAsync(int userId, int taskId)
    {
      try
      {
        bool deleted = await _taskItemRepository.DeleteTaskAsync(userId, taskId);
        if (!deleted)
          throw new KeyNotFoundException("Task not found or already deleted.");

        return true;
      }
      catch (DbUpdateException dbEx)
      {
        throw new InvalidOperationException("Database update failed while deleting task.", dbEx);
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException("Failed to delete task.", ex);
      }
    }
  }
}
