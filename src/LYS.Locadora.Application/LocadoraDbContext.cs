using LYS.Locadora.Application.Model;
using LYS.Locadora.Application.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LYS.Locadora.Application;

internal class LocadoraDbContext(IConfiguration appConfig) : DbContext, ILocadoraRepository
{
    public DbSet<Movie> Movies { get; set; }
    IAsyncEnumerable<Movie> ILocadoraRepository.Movies => Movies.AsAsyncEnumerable();

    public new TEntity Add<TEntity>(TEntity entity) where TEntity : class
    {
        return base.Add(entity).Entity;
    }

    public new TEntity Update<TEntity>(TEntity entity) where TEntity : class
    {
        return base.Update(entity).Entity;
    }

    public TEntity Delete<TEntity>(TEntity entity) where TEntity : class
    {
        return base.Remove(entity).Entity;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(appConfig.GetConnectionString("LocadoraDb"));
    }
}