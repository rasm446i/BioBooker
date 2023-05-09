using Microsoft.AspNetCore.Mvc;
using BioBooker.WebApi.Bll;
using Microsoft.Extensions.Configuration;
using BioBooker.Dml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BioBooker.WebApi.Ctl.Controllers;

[Route("movies")]
[ApiController]
public class MoviesController : ControllerBase
{

    private readonly IConfiguration _configuration;
    private readonly MoviesManager _moviesManager;

    // Constructor
    public MoviesController(IConfiguration inConfiguration)
    {
        _configuration = inConfiguration;
        _moviesManager = new MoviesManager(_configuration);
    }

    [HttpPost]
    [AllowAnonymous]
    // Inserts a new movie into the database using the _moviesManager.InsertMovieAsync() method.
    // Returns Ok() if the insertion was successful, otherwise returns a StatusCodeResult with code 500.
    public async Task<IActionResult> Post([FromBody] Movie movie)
    {
        IActionResult inserted;
        bool wasOk = await _moviesManager.InsertMovieAsync(movie);
        if (wasOk)
        {
            inserted = Ok();
        }
        else
        {
            inserted = new StatusCodeResult(500);
        }
        return inserted;
    }

    [HttpGet]
    [AllowAnonymous]
    // Retrieves a movie from the database by its title using the _moviesManager.GetMovieByTitleAsync() method.
    // Returns Ok(movie) if the movie is found, otherwise returns NotFound().
    public async Task<IActionResult> Get([FromQuery] string title)
    {
        Movie movie = await _moviesManager.GetMovieByTitleAsync(title);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpGet("all")]
    [AllowAnonymous]
    // Retrieves all movies from the database using the _moviesManager.GetAllMoviesAsync() method.
    // Returns Ok(movies) if movies are found, otherwise returns NotFound().
    public async Task<IActionResult> Get()
    {
        List<Movie> movies = await _moviesManager.GetAllMoviesAsync();

        if (movies == null)
        {
            return NotFound();
        }

        return Ok(movies);
    }



}