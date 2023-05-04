using Microsoft.AspNetCore.Mvc;
using BioBooker.WebApi.Bll;
using Microsoft.Extensions.Configuration;
using BioBooker.Dml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BioBooker.WebApi.Ctl.Controllers;

[Route("/movies")]
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
    public async Task<IActionResult> InsertMovie([FromBody] Movie movie)
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


}