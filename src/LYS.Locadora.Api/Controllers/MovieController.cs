using LYS.Locadora.Api.ViewModel;
using LYS.Locadora.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LYS.Locadora.Api.Mapping;

namespace LYS.Locadora.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController(IMovieService movieService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<MovieViewModel>>> AllMovies()
    {
        var movie = await movieService.GetAllMoviesAsync();
        return movie.Select(x => x.ToViewModel()).ToList();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieViewModel>> FindById(int id)
    {
        var movie = await movieService.GetMovieByIdAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return movie.ToViewModel();
    }

    [HttpPost]
    public async Task<ActionResult> CreateMovie(MovieCreateViewModel param)
    {
        var movie = param.ToEntity();
        var result = await movieService.CreateMovieAsync(movie);
        
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateMovie(int id, MoviewUpdateViewModel param)
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