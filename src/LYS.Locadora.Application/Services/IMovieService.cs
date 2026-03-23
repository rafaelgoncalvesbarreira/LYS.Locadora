using LYS.Locadora.Application.Model;

namespace LYS.Locadora.Application.Services;

public interface IMovieService
{
    Task<List<Movie>> GetAllMoviesAsync(int page = 1, int pageSize = 20);
    Task<Movie?> GetMovieByIdAsync(int id);
    Task<List<Movie>> QueryMoviesAsync(Func<Movie, bool> predicate, int page = 1, int pageSize = 20);
    Task<Movie?> CreateMovieAsync(Movie movie);
    Task<Movie?> UpdateMovieAsync(Movie movie);
    Task DeleteMovieAsync(int id);
}