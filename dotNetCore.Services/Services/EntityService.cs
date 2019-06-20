using dotNetCore.Services.Database.Entity;
using dotNetCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace dotNetCore.Services.Services
{
  public abstract class EntityService<T> : IEntityService<T> where T : class
  {
    protected Database.Entity.EntityDbContext _dbContext;
    protected DbSet<T> _dbSet;

    public EntityService(Database.Entity.EntityDbContext context)
    {
      _dbContext = context;
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
      if (entity != null)
      {
        _dbSet.Add(entity);
        await _dbContext.SaveChangesAsync();
      }
      return entity;
    }

    public virtual void Delete(T entity)
    {
      //throw new ArgumentNullException("entity");
      if (entity != null)
      {
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
      }
    }

    public virtual IQueryable<T> GetAll()
    {
      return _dbSet.AsQueryable();
    }

    public virtual T GetData(Expression<Func<T, bool>> predicate)
    {
      return _dbSet.Where(predicate).FirstOrDefault();
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
      if (entity != null)
      {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
      }
      return entity;
    }
  }
}
