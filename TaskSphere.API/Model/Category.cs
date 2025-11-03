namespace TaskSphere.API.Model
{
  public class Category
  {
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public string Name { get; set; } = null!;
    public string? Icon { get; set; }
    public string? ColorHex { get; set; }

    public ICollection<TaskItem> Tasks { get; set; } = [];
  }
}
