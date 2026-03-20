using LYS.Locadora.Application.Model;
using LYS.Locadora.Application.Repository;

namespace LYS.Locadora.Application.Services.Implementation;

internal class MovieService(ILocadoraRepository repository) : IMovieService
{
    public ValueTask<List<Movie>> GetAllMoviesAsync(int pageSize = 10)
    {
        if (pageSize < 1 || pageSize > 100)
        {
            pageSize = 10;
        }
        
        return repository.Movies.Take(pageSize).ToListAsync();
    }

    public ValueTask<Movie?> GetMovieByIdAsync(int id)
    {
        return repository.Movies.FirstOrDefaultAsync(m => m.Id == id);
    }

    public ValueTask<List<Movie>> QueryMoviesAsync(Func<Movie, bool> predicate, int pageSize = 10)
    {
        if (pageSize < 1 || pageSize > 100)
        {
            pageSize = 10;
        }
        
        return repository.Movies.Where(predicate).ToListAsync();
    }

    public async Task<Movie?> CreateMovieAsync(Movie movie)
    {
        repository.Add(movie);
        await repository.SaveChangesAsync();

        return movie;
    }

    public async Task<Movie?> UpdateMovieAsync(Movie movie)
    { 
        repository.Update(movie);
        await repository.SaveChangesAsync();

        return movie;
    }

    public async Task DeleteMovieAsync(int id)
    {
        var movie = await repository.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (movie != null)
        {
            repository.Delete(movie);
            await repository.SaveChangesAsync();
        }
    }
}