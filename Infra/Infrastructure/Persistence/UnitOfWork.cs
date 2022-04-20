using Application.Common.Interfaces;
using Domain.Master;
using Domain.Product;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence
{
  internal class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDBContext _context;

    public UnitOfWork(ApplicationDBContext context)
    {
      _context = context;
    }

    private IRepository<AppSetting> _appSettingRepo;
    public IRepository<AppSetting> AppSettingRepo
    {
      get 
      {
        if(_appSettingRepo == null)
          _appSettingRepo = new EfRepository<AppSetting>(_context);
        return _appSettingRepo;  
      }
    }
    private IRepository<Category> _categoryRepo;
    public IRepository<Category> CategoryRepo
    {
      get 
      {
        if(_categoryRepo == null)
          _categoryRepo = new EfRepository<Category>(_context);
        return _categoryRepo;        
      }
    }
    public async Task<int> SaveAsync()
    {
      return await _context.SaveChangesAsync();
    }
    public int Save()
    {
      return _context.SaveChanges();
    }

    IDbContextTransaction dbContextTransaction; 
    public void BeginTransaction()
    {
      dbContextTransaction = _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
      if(dbContextTransaction != null)
        dbContextTransaction.Commit();
    }

    public void RollbackTransaction()
    {
      if(dbContextTransaction != null) 
        dbContextTransaction.Rollback();
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
      if(!this.disposed)
      {
        if(disposing)
          _context.Dispose();
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }

}