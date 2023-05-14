using BioBooker.Dml;
using BioBooker.WebApi.Bll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Post([FromBody] MovieTheater newMovieTheater)
        {

            if (newMovieTheater == null)
            {
                return BadRequest();
            }
            bool wasInserted = await _movieTheaterBusiness.InsertMovieTheaterAsync(newMovieTheater);

            if (wasInserted)
            {
                return CreatedAtAction(nameof(Post), newMovieTheater);

            }
            return StatusCode(500);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<MovieTheater> movieTheaters = await _movieTheaterBusiness.GetAllMovieTheatersAsync();

            if (movieTheaters == null || movieTheaters.Count == 0)
            {
                return NotFound();
            }
            return Ok(movieTheaters);
        }

        [HttpGet, Route("{id}/Auditoriums")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            List<Auditorium> auditoriums = await _movieTheaterBusiness.GetAllAuditoriumsFromMovieTheaterIdAsync(id);

            if (auditoriums == null || auditoriums.Count == 0)
            {
                return NotFound();

            }
            return Ok(auditoriums);
        }

        [HttpPost, Route("{id}/Auditoriums/{auditoriumId}/Seats")]
        public async Task<IActionResult> Post(List<Seat> seats, [FromRoute] int auditoriumId)
        {
            if (auditoriumId <= 0)
            {
                return BadRequest("Invalid auditorium id");
            }

            if (seats == null || seats.Count == 0)
            {
                return BadRequest("Seat list is null or empty");
            }

            bool wasAdded = await _movieTheaterBusiness.InsertSeatsAsync(seats, auditoriumId);

            if (!wasAdded)
            {
                return BadRequest("Failed to add seats to auditorium");
            }
            else
            {
                return CreatedAtAction(nameof(Post), seats, auditoriumId);
            }

        }

        [HttpPost("{movieTheaterId}/auditoriums")]
        public async Task<IActionResult> InsertAuditoriumToMovieTheater(int movieTheaterId, [FromBody] Auditorium newAuditorium)
        {
            if (movieTheaterId <= 0)
            {
                return BadRequest("Invalid movie theater id");
            }

            if (newAuditorium == null)
            {
                return BadRequest("Auditorium data is null");
            }

            if (string.IsNullOrEmpty(newAuditorium.Name) || newAuditorium.Seats.Count <= 0)
            {
                return BadRequest("Invalid auditorium data");
            }

            bool wasSaved = await _movieTheaterBusiness.InsertAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

            if (wasSaved)
            {
                return CreatedAtAction(nameof(InsertAuditoriumToMovieTheater), new { movieTheaterId, id = newAuditorium.AuditoriumId }, newAuditorium);
            }

            else
            {
                return BadRequest("Failed to insert auditorium to movie theater");
            }
        }

        [HttpGet("{movieTheaterId}/auditoriums/{auditoriumName}")]
        public async Task<IActionResult> GetAuditoriumByNameAndMovieTheaterId([FromRoute] int movieTheaterId, [FromRoute] string auditoriumName)
        {
            if (movieTheaterId <= 0)
            {
                return BadRequest("Invalid movie theater id.");
            }

            if (string.IsNullOrEmpty(auditoriumName))
            {
                return BadRequest("Auditorium name must not be empty");
            }

            Auditorium foundAuditorium = await _movieTheaterBusiness.GetAuditoriumByNameAndMovieTheaterIdAsync(auditoriumName, movieTheaterId);
            if (foundAuditorium == null)
            {
                return NotFound("Auditorium not found.");
            }
            return Ok(foundAuditorium);
        }

    }

}


