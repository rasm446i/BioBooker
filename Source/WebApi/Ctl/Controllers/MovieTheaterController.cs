using BioBooker.Dml;
using BioBooker.WebApi.Bll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
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

        [HttpGet, Route("{id}/Auditoriums")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            List<Auditorium> auditorium = await _movieTheaterBusiness.GetAllAuditoriumsFromMovieTheaterIdAsync(id);

            if (auditorium == null)
            {
                return NotFound();

            }
            return Ok(auditorium);
        }

        [HttpPost, Route("{id}/Auditoriums/{auditoriumId}/Seats")]
        public async Task<IActionResult> Post(List<Seat> Seats, [FromRoute] int auditoriumId)
        {

            bool wasAdded = await _movieTheaterBusiness.InsertSeatsAsync(Seats, auditoriumId);

            if (!wasAdded)
            {
                return NotFound();
            }
            else
            {
                return CreatedAtAction(nameof(Post), Seats);
            }

        }

        [HttpPost("{movieTheaterId}/auditoriums")]
        public async Task<IActionResult> InsertAuditoriumToMovieTheater(int movieTheaterId, [FromBody] Auditorium newAuditorium)
        {
            if (ModelState.IsValid)
            {
                bool wasSaved = await _movieTheaterBusiness.InsertAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

                if (wasSaved)
                {
                    return CreatedAtAction(nameof(InsertAuditoriumToMovieTheater), new { movieTheaterId, id = newAuditorium.AuditoriumId }, newAuditorium);
                }

                else
                {
                    return BadRequest("Failed to insert auditorium to movie theater.");
                }
            }
            else
            {
                return BadRequest("Invalid input data.");
            }
        }

        [HttpGet("{movieTheaterId}/auditoriums/{auditoriumName}")]
        public async Task<IActionResult> GetAuditoriumByNameAndMovieTheaterId([FromRoute] int movieTheaterId, [FromRoute] string auditoriumName)
        {
            if (string.IsNullOrEmpty(auditoriumName))
            {
                return BadRequest("Auditorium name must not be empty");
            }

                Auditorium foundAuditorium = await _movieTheaterBusiness.GetAuditoriumByNameAndMovieTheaterIdAsync(auditoriumName, movieTheaterId);
                if (foundAuditorium == null)
                {
                    return NotFound();
                }
                return Ok(foundAuditorium);
            }
        }



    }

}
