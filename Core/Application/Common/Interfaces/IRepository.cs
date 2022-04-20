
using System.Linq.Expressions;

namespace Application.Common.Interfaces
{

  public interface IRepository<T> where T : class
  {

    void Add(T entity);  
    void Update(T entity);
    Task<bool> Delete(object id);  
    Task<bool> Delete(T entity);  
    Task<bool> Delete(Expression<Func<T, bool>> where);  
    Task<T> Get(object id);
    Task<T> Get(Expression<Func<T, bool>> where);
    IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    IEnumerable<T> GetAll();
    Task<int> Count(Expression<Func<T, bool>> where);
    Task<int> Count();

    IQueryable<T> Table { get; }
    IQueryable<T> TableNoTracking { get; }
  }

}