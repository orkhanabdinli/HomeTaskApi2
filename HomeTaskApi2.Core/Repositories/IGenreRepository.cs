using HomeTaskApi2.Core.Entities;
using System.Linq.Expressions;

namespace HomeTaskApi2.Core.Repositories;

public interface IGenreRepository
{
    Task InsertAsync(Genre genre);
    void Delete(Genre genre);
    Task<IEnumerable<Genre>> GetAllAsync(Expression<Func<Genre, bool>> expression = null, params string[] includes);
    Task<Genre> GetAsync(Expression<Func<Genre, bool>> expression = null, params string[] includes);
    Task<Genre> GetByIdAsync(int id);
    Task<int> CommitAsync();

}
