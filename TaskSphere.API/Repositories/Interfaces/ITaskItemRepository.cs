using TaskSphere.API.Model;

namespace TaskSphere.API.Repositories.Interfaces
{
  public interface ITaskItemRepository
  {
    Task<IEnumerable<TaskItem>> GetTasksAsync(int userId);
    Task<TaskItem?> GetTaskByIdAsync(int userId, int taskId);
    Task<TaskItem> CreateTaskAsync(TaskItem task);
    Task<TaskItem> UpdateTaskAsync(TaskItem task);
    Task<bool> DeleteTaskAsync(int userId, int taskId);
  }
}