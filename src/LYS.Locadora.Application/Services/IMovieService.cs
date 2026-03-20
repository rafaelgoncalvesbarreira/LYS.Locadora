using LYS.Locadora.Application.Model;

namespace LYS.Locadora.Application.Services;

public interface IMovieService
{
    ValueTask<List<Movie>> GetAllMoviesAsync(int pageSize = 10);
    ValueTask<Movie?> GetMovieByIdAsync(int id);
    ValueTask<List<Movie>> QueryMoviesAsync(Func<Movie, bool> predicate, int pageSize = 10);
    Task<Movie?> CreateMovieAsync(Movie movie);
    Task<Movie?> UpdateMovieAsync(Movie movie);
    Task DeleteMovieAsync(int id);
}