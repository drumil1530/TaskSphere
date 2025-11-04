using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskSphere.API.Repositories.Interfaces
{
  public interface ICategoryRepository
  {
    Task<bool> ExistsForUserAsync(int categoryId, int userId);
  }
}