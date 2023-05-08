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
    public async Task<IActionResult> InsertMovieAsync([FromBody] Movie movie)
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
    public async Task<IActionResult> GetMovieByTitleAsync([FromQuery] string title)
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
    public async Task<IActionResult> GetAllMoviesAsync()
    {
        List<Movie> movies = await _moviesManager.GetAllMoviesAsync();

        if (movies == null)
        {
            return NotFound();
        }

        return Ok(movies);
    }



}