using LYS.Locadora.Application.Context;
using LYS.Locadora.Application.Model;
using Microsoft.EntityFrameworkCore;

namespace LYS.Locadora.Application.Services.Implementation;

internal class MovieService(LocadoraDbContext dbContext) : IMovieService
{
    public Task<List<Movie>> GetAllMoviesAsync(int page = 1, int pageSize = 20)
    {
        if (pageSize is < 1 or > 100)
        {
            pageSize = 10;
        }
        
        var skip = (page - 1) * pageSize;

        return dbContext.Movies.Skip(skip).Take(pageSize).ToListAsync();
    }

    public Task<Movie?> GetMovieByIdAsync(int id)
    {
        return dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
    }

    public Task<List<Movie>> QueryMoviesAsync(Func<Movie, bool> predicate, int page = 1, int pageSize = 20)
    {
        if (pageSize is < 1 or > 100)
        {
            pageSize = 20;
        }
        
        var skip = (page - 1) * pageSize;

        return dbContext.Movies.Skip(skip).Take(pageSize).AsQueryable().ToListAsync();
    }

    public async Task<Movie?> CreateMovieAsync(Movie movie)
    {
        dbContext.Add<Movie>(movie);
        await dbContext.SaveChangesAsync();

        return movie;
    }

    public async Task<Movie?> UpdateMovieAsync(Movie movie)
    { 
        dbContext.Entry(movie).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();

        return movie;
    }

    public async Task DeleteMovieAsync(int id)
    {
        var movie = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (movie != null)
        {
            dbContext.Movies.Remove(movie);
            await dbContext.SaveChangesAsync();
        }
    }
}