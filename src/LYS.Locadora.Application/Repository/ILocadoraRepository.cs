using LYS.Locadora.Application.Model;

namespace LYS.Locadora.Application.Repository;

public interface ILocadoraRepository
{
    public IAsyncEnumerable<Movie> Movies { get; }

    public TEntity Add<TEntity>(TEntity entity) where TEntity: class;
    
    public TEntity Update<TEntity>(TEntity entity) where TEntity: class;
    
    public TEntity Delete<TEntity>(TEntity entity) where TEntity: class;
    
    public Task<int> SaveChangesAsync();
}