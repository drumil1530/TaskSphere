using TaskSphere.API.Model.Enums;

namespace TaskSphere.API.DTOs.TaskItem
{
  public class TaskItemDto
  {
    public int? Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
    public int Priority { get; set; } = 1;
    public DateTime StartTime { get; set; }
    public DateTime DueTime { get; set; }
    public TaskRepeatType RepeatType { get; set; } = TaskRepeatType.None;
    public bool AutoStatus { get; set; } = false;
    public string? ColorHex { get; set; }
  }
}