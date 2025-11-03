namespace TaskSphere.API.Model
{
  public class TaskOccurrence
  {
    public int Id { get; set; }

    public int TaskItemId { get; set; }
    public TaskItem TaskItem { get; set; } = null!;

    public DateOnly Date { get; set; }

    public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.Pending;

    public DateTime? UpdatedAt { get; set; }
  }
}
