using Microsoft.AspNetCore.Mvc;
using BioBooker.WebApi.Bll;
using Microsoft.Extensions.Configuration;
using BioBooker.Dml;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Ctl.Controllers;

    [ApiController]
    [Route("/movies")]

public class MoviesController : ControllerBase
{



    private readonly IConfiguration _configuration;
    private readonly MoviesManager _MoviesManager;

    // Constructor
    public MoviesController(IConfiguration inConfiguration)
    {
        _configuration = inConfiguration;
        _MoviesManager = new MoviesManager(_configuration);
    }

    [HttpPost]

    public async Task<IActionResult> InsertMovie([FromBody]Movie movie)
    {
        IActionResult foundToReturn;

        bool wasOk = await _MoviesManager.InsertMovie(movie);
       
    }


}