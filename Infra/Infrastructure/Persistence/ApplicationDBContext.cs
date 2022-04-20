using Application.Common.Interfaces;
using Domain.Common;
using Domain.Master;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
  public class ApplicationDBContext : DbContext, IApplicationBDContext
  {
    private readonly DateTime _currentDateTime;
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
      _currentDateTime = DateTime.Now;
    }

    public DbSet<AppSetting> AppSettings { get; set; }
    public DbSet<Category> Categories { get; set; }

    public Task<int> SaveChangesAsync()
    {
      foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
      {
        switch(entry.State)
        {
          case EntityState.Added:
            entry.Entity.CreatedBy = 1;
            entry.Entity.CreatedAt = _currentDateTime;
            entry.Entity.UpdatedBy = 1;
            entry.Entity.UpdatedAt = _currentDateTime;
            break;
          case EntityState.Modified:  
            entry.Entity.UpdatedBy = 1;
            entry.Entity.UpdatedAt = _currentDateTime;
            break;
        }
      }
      return base.SaveChangesAsync();
    }
    public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
      return base.Set<TEntity>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }
  }
}