using LYS.Locadora.Api.ViewModel;
using LYS.Locadora.Application.Model;

namespace LYS.Locadora.Api.Mapping;

public static class MovieExtensions
{
    public static MovieViewModel ToViewModel(this Movie movie)
    {
        return new MovieViewModel(movie.Id, movie.Title, movie.ReleaseDate, movie.Genre, movie.Rating, movie.ImageUrl);
    }
    
    public static Movie ToEntity(this MovieCreateViewModel movie)
    {
        return new Movie()
        {
            Title = movie.Title,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Rating = movie.Rating,
            ImageUrl = movie.ImageUrl,
        };
    }
    
    public static Movie ToEntity(this MoviewUpdateViewModel movie)
    {
        return new Movie()
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Rating = movie.Rating,
            ImageUrl = movie.ImageUrl,
        };
    }
    
}