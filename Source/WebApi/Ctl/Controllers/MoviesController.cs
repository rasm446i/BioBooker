using Microsoft.AspNetCore.Mvc;
using BioBooker.WebApi.Bll;
using Microsoft.Extensions.Configuration;
using BioBooker.Dml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;

namespace BioBooker.WebApi.Ctl.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [AllowAnonymous]
    public class MoviesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMoviesManager _moviesManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesController"/> class.
        /// </summary>
        /// <param name="inConfiguration">The configuration object.</param>
        public MoviesController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _moviesManager = new MoviesManager(_configuration);
        }

        /// <summary>
        /// Inserts a new movie into the database.
        /// </summary>
        /// <param name="movie">The movie to insert.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost]
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

        /// <summary>
        /// Retrieves a movie from the database by its title.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("{title}")]
        public async Task<IActionResult> GetByTitle([FromQuery] string title)
        {
            Movie movie = await _moviesManager.GetMovieByTitleAsync(title);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        /// <summary>
        /// Retrieves a movie from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("id/{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Movie movie = await _moviesManager.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        /// <summary>
        /// Retrieves all movies from the database.
        /// </summary>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Movie> movies = await _moviesManager.GetAllMoviesAsync();

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        /// <summary>
        /// Deletes a movie from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool wasDeleted = await _moviesManager.DeleteMovieByIdAsync(id);

            if (wasDeleted)
            {
                return Ok();
            }

            return NotFound();
        }

        /// <summary>
        /// Updates a movie in the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="updatedMovie">The updated movie object.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Movie updatedMovie)
        {
            bool wasUpdated = await _moviesManager.UpdateMovieByIdAsync(id, updatedMovie);

            if (wasUpdated)
            {
                return Ok();
            }

            return NotFound();
        }

        /// <summary>
        /// Retrieves the list of showings for a specific movie.
        /// </summary>
        /// <param name="movieId">The ID of the movie.</param>
        /// <returns>The list of showings for the specified movie.</returns>
        [HttpGet("{movieId}/showings")]
        public async Task<IActionResult> Get(int movieId)
        {
            try
            {
                List<Showing> retrievedShowings = await _moviesManager.GetShowingsByMovieIdAsync(movieId);

                if (retrievedShowings == null || retrievedShowings.Count == 0)
                {
                    return NotFound();
                }

                return Ok(retrievedShowings);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
           
}
