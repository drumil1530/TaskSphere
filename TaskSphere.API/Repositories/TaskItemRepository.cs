using Microsoft.EntityFrameworkCore;
using TaskSphere.API.Data;
using TaskSphere.API.Model;
using TaskSphere.API.Repositories.Interfaces;

namespace TaskSphere.API.Repositories
{
  public class TaskItemRepository : ITaskItemRepository
  {
    private readonly AppDbContext _context;

    public TaskItemRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetTasksAsync(int userId)
    {
      return await _context.TaskItems
        .Where(t => t.UserId == userId)
        .Include(t => t.Category)
        .ToListAsync();
    }

    public async Task<TaskItem?> GetTaskByIdAsync(int userId, int taskId)
    {
      return await _context.TaskItems
        .Include(t => t.Category)
        .FirstOrDefaultAsync(t => t.UserId == userId && t.Id == taskId);
    }

    public async Task<TaskItem> CreateTaskAsync(TaskItem task)
    {
      await _context.TaskItems.AddAsync(task);
      await _context.SaveChangesAsync();
      return task;
    }

    public async Task<TaskItem> UpdateTaskAsync(TaskItem task)
    {
      var local = _context.Set<TaskItem>()
          .Local
          .FirstOrDefault(entry => entry.Id == task.Id);

      if (local != null)
        _context.Entry(local).State = EntityState.Detached;

      _context.TaskItems.Update(task);
      await _context.SaveChangesAsync();
      return task;
    }

    public async Task<bool> DeleteTaskAsync(int userId, int taskId)
    {
      TaskItem? task = await _context.TaskItems.FirstOrDefaultAsync(t => t.UserId == userId && t.Id == taskId);
      if (task == null)
        return false;

      _context.TaskItems.Remove(task);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}