using HomeTaskApi2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeTaskApi2.Core.Repositories;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
{
    DbSet<TEntity> Table {  get; }
    Task InsertAsync(TEntity entity);
    void Delete(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, params string[] includes);
    Task<TEntity> GetByIdAsync(int id);
    Task CommitAsync();
}
