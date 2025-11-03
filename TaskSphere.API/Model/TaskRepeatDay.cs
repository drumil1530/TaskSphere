namespace TaskSphere.API.Model
{
  public class TaskRepeatDay
  {
    public int Id { get; set; }

    public int TaskItemId { get; set; }
    public TaskItem TaskItem { get; set; } = null!;

    // String representation of DayOfWeek
    public DayOfWeek DayOfWeek { get; set; }
  }
}
