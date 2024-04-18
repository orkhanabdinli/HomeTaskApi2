using HomeTaskApi2.Core.Entities;
using HomeTaskApi2.Core.Repositories;
using HomeTaskApi2.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeTaskApi2.Data.Repositories;

public class GenericRepository<TEntiry> : IGenericRepository<TEntiry> where TEntiry : BaseEntity, new()
{
    private readonly HomeTaskApi2DbContext _context;

    public GenericRepository(HomeTaskApi2DbContext context)
    {
        _context = context;
    }
    public DbSet<TEntiry> Table => _context.Set<TEntiry>();

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Delete(TEntiry entity)
    {
        Table.Remove(entity);
    }

    public async Task<IEnumerable<TEntiry>> GetAllAsync(Expression<Func<TEntiry, bool>> expression = null, params string[] includes)
    {
        var query = Table.AsQueryable();
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

    public async Task<TEntiry> GetAsync(Expression<Func<TEntiry, bool>> expression = null, params string[] includes)
    {
        var query = Table.AsQueryable();
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

    public async Task<TEntiry> GetByIdAsync(int id)
    {
        return await Table.FindAsync(id);
    }

    public async Task InsertAsync(TEntiry entity)
    {
        await Table.AddAsync(entity);
    }
}
