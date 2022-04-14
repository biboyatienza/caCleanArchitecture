using Domain.Master;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
  public interface IApplicationBDContext
  {
    DbSet<AppSetting> AppSettings { get; set; }
    Task<int> SaveChangesAsync();
  }
}