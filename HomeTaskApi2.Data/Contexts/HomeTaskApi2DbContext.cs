using HomeTaskApi2.Core.Entities;
using HomeTaskApi2.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskApi2.Data.Contexts;

public class HomeTaskApi2DbContext : DbContext
{
	public HomeTaskApi2DbContext(DbContextOptions<HomeTaskApi2DbContext> options) : base(options){}
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenreConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
