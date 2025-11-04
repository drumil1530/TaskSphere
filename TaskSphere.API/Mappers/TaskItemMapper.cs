using TaskSphere.API.DTOs.TaskItem;
using TaskSphere.API.Model;

namespace TaskSphere.API.Mappers
{
  public static class TaskItemMapper
  {
    public static TaskItem ToTaskItem(this TaskItemDto dto, int userId) => new()
    {
      Id = dto.Id ?? 0,
      UserId = userId,
      Title = dto.Title,
      Description = dto.Description,
      CategoryId = dto.CategoryId,
      Priority = dto.Priority == 0 ? 1 : dto.Priority,
      StartTime = dto.StartTime,
      DueTime = dto.DueTime,
      RepeatType = dto.RepeatType,
      AutoStatus = dto.AutoStatus,
      ColorHex = dto.ColorHex
    };

    public static TaskItemDto ToTaskItemDto(this TaskItem task) => new()
    {
      Id = task.Id,
      Title = task.Title,
      Description = task.Description,
      CategoryId = task.CategoryId,
      Priority = task.Priority,
      StartTime = task.StartTime,
      DueTime = task.DueTime,
      RepeatType = task.RepeatType,
      AutoStatus = task.AutoStatus,
      ColorHex = task.ColorHex
    };
  }
}