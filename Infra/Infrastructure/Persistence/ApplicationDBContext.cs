using Application.Common.Interfaces;
using Domain.Master;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
  public class ApplicationDBContext : DbContext, IApplicationBDContext
  {
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
      
    }

    public DbSet<AppSetting> AppSettings { get; set; }

    public Task<int> SaveChangesAsync()
    {
      return base.SaveChangesAsync();
    }
  }
}