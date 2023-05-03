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

namespace BioBooker.WebApi.Ctl.Controllers
{
    [Route("api/movieTheaters")]
    [ApiController]
    public class MovieTheaterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MovieTheaterBusiness _movieTheaterBusiness;
        public MovieTheaterController(IConfiguration inConfiguration) 
        {
        _configuration = inConfiguration;
            _movieTheaterBusiness = new MovieTheaterBusiness(_configuration);
        
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
           List<MovieTheater> movieTheaters = await Task.Run(() => _movieTheaterBusiness.GetAllMovieTheaters());

            return Ok(movieTheaters);
        }

       // [HttpGet, Route("{id}")]
      //  public async Task<IActionResult> GetMovieTheaterWithId([FromRoute] int id ) 
      //  {


     //   }
        












    }
}
