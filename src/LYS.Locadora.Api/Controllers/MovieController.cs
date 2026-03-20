using LYS.Locadora.Api.ViewModel;
using LYS.Locadora.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LYS.Locadora.Api.Mapping;

namespace LYS.Locadora.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController(IMovieService movieService) : ControllerBase
{
    [HttpGet]
    public async Task<List<MovieViewModel>> AllMovies()
    {
        var movie = await movieService.GetAllMoviesAsync();
        return movie.Select(x => x.ToViewModel()).ToList();
    }
    
    [HttpGet("{id}")]
    public async Task<MovieViewModel> FindById(int id)
    {
        var movie = await movieService.GetMovieByIdAsync(id);
        return movie.ToViewModel();
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie(MovieCreateViewModel param)
    {
        var movie = param.ToEntity();
        var result = await movieService.CreateMovieAsync(movie);
        
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMovie(int id, MoviewUpdateViewModel param)
    {
        var movie = param.ToEntity();
        var result = await movieService.UpdateMovieAsync(movie);
        
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        await  movieService.DeleteMovieAsync(id);
        return Ok(); 
    }
}