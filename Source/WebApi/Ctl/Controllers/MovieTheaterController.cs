using BioBooker.Dml;
using BioBooker.WinApp.Svl;
using BioBooker.WebApi.Bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Web.Http.Results;

namespace BioBooker.WebApi.Ctl.Controllers
{
    [Route("api/movieTheaters")]
    [ApiController]
    [AllowAnonymous]
    public class MovieTheaterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MovieTheaterBusiness _movieTheaterBusiness;
        public MovieTheaterController(IConfiguration inConfiguration) 
        {
        _configuration = inConfiguration;
            _movieTheaterBusiness = new MovieTheaterBusiness(_configuration);
        
        }
        [HttpPost]
        public async Task<IActionResult> Post(MovieTheater newMovieTheater)
        {
            bool wasInserted;

            if (newMovieTheater != null)
            {
                wasInserted = await _movieTheaterBusiness.InsertMovieTheaterAsync(newMovieTheater);

                if (wasInserted)
                {
                    return CreatedAtAction(nameof(Post), newMovieTheater);
                }
                else
                {
                    //409 conflict response if movie theater already exists
                    //currently also returns 409 if server is down (have to compare by name instead)
                    return Conflict("Movie theater already exists");
                }

            }
            else
            {
                {
                    BadRequest();
                }
              
            }
            return StatusCode(500);
        }
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                List<MovieTheater> movieTheaters = await _movieTheaterBusiness.GetAllMovieTheatersAsync();

                if (movieTheaters == null)
                {
                    return NotFound();
                }
                return Ok(movieTheaters);
            }

            // [HttpGet, Route("{id}")]
            //  public async Task<IActionResult> GetMovieTheaterWithId([FromRoute] int id ) 
            //  {

            //   }

        
    }
}
