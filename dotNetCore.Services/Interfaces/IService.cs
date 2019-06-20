using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dotNetCore.Services.Interfaces
{
  public interface IService
  {
  }

  public interface IEntityService<T> : IService
  {
    Task<T> CreateAsync(T entity);
    void Delete(T entity);
    IQueryable<T> GetAll();
    T GetData(Expression<Func<T, bool>> predicate);
    Task<T> UpdateAsync(T entity);
  }
}
