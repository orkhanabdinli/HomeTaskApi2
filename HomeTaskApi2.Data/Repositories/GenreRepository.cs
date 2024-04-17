using HomeTaskApi2.Core.Entities;
using HomeTaskApi2.Core.Repositories;
using HomeTaskApi2.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeTaskApi2.Data.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly HomeTaskApi2DbContext _context;

    public GenreRepository(HomeTaskApi2DbContext context)
    {
        _context = context;
    }
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Delete(Genre genre)
    {
        _context.Genres.Remove(genre);
    }

    public async Task<IEnumerable<Genre>> GetAllAsync(Expression<Func<Genre, bool>> expression = null, params string[] includes)
    {
        var query = _context.Genres.AsQueryable();
        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return expression is not null
            ? await query.Where(expression).ToListAsync()
            : await query.ToListAsync();
    }

    public async Task<Genre> GetAsync(Expression<Func<Genre, bool>> expression = null, params string[] includes)
    {
        var query = _context.Genres.AsQueryable();
        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return expression is not null 
            ? await query.Where(expression).FirstOrDefaultAsync() 
            : await query.FirstOrDefaultAsync();
    }

    public async Task<Genre> GetByIdAsync(int id)
    {
        return await _context.Genres.FindAsync(id);
    }

    public async Task InsertAsync(Genre genre)
    {
        await _context.Genres.AddAsync(genre);
    }
}
