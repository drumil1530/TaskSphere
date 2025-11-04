namespace TaskSphere.API.Services.Interfaces
{
  public interface IUserContextService
  {
    int GetUserId();
    string? GetUsername();
    string? GetEmail();
  }
}
