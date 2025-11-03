using TaskSphere.API.Model.Enums;

namespace TaskSphere.API.Model
{
  public class TaskItem
  {
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public int Priority { get; set; } = 1;

    public DateTime StartTime { get; set; }
    public DateTime DueTime { get; set; }

    public TaskRepeatType RepeatType { get; set; } = TaskRepeatType.None;

    public bool AutoStatus { get; set; } = false;
    public bool IsActive { get; set; } = true;

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public string? ColorHex { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<TaskOccurrence> Occurrences { get; set; } = [];
    public ICollection<TaskRepeatDay> RepeatDays { get; set; } = [];
  }
}
