using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence
{
  internal class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    private readonly ApplicationDBContext _context;
    protected DbSet<TEntity> _entities;

    public EfRepository(ApplicationDBContext context)
    {
      _context = context;
    }

    protected virtual DbSet<TEntity> Entities
    {
      get 
      {
        if(_entities == null) 
          _entities = _context.Set<TEntity>();

        return _entities;        
      }
    }

    public virtual void Save() => _context.SaveChanges();
    public virtual void SaveAsync() => _context.SaveChangesAsync();

    public virtual void Add(TEntity entity)
    {
      try
      {
        if(entity == null)
          throw new ArgumentException(nameof(entity));
        Entities.AddAsync(entity);  
      }
      catch (Exception)
      {
        throw;
      }
    }

    public virtual void Update(TEntity entity)
    {
      try
      {
        if(entity == null)
          throw new ArgumentException(nameof(entity));
        Entities.Update(entity);
      }
      catch (Exception)
      {
        throw;
      }  
 
    }

    public virtual async Task<bool> Delete(object id)
    {
      try
      {
        var entity = await Entities.FindAsync(id);
        if(entity == null)
          return false;
        Entities.Remove(entity);
        return false;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public virtual async Task<bool> Delete(TEntity entity)
    {
      try
      {
        if(entity == null)
          // return false;
          return await Task.FromResult<bool>(false);          
        Entities.Remove(entity);
          // return true;
        return await Task.FromResult<bool>(true);          
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    public virtual async Task<bool> Delete(Expression<Func<TEntity, bool>> where)
    {
      try
      {
        var entities = Entities.Where(where);
        Entities.RemoveRange(entities);
        // return true;
        return await Task.FromResult<bool>(true);   
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    public virtual async Task<TEntity> Get(object id)
    {
      try
      {
        return await Entities.FindAsync(id);
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> where)
    {
      try
      {
        return await Entities.FirstOrDefaultAsync(where);
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
      try
      {
        return Entities;
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    public virtual IEnumerable<TEntity> GetMany(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
    {
      try
      {
        return Entities.Where(where);        
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    public virtual async Task<int> Count(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
    {
      try
      {
        return await Entities.CountAsync(where);
      }
      catch (System.Exception)
      {
        throw;
      }    
    }

    public virtual async Task<int> Count()
    {
      try
      {
        return await Entities.CountAsync();        
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    public virtual IQueryable<TEntity> Table => Entities;

    public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();
  }

}