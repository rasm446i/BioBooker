using Microsoft.AspNetCore.Mvc;
using BioBooker.WebApi.Bll;
using Microsoft.Extensions.Configuration;
using BioBooker.Dml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace BioBooker.WebApi.Ctl.Controllers
{
    [Route("movies")]
    [ApiController]
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
        [AllowAnonymous]
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
        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [HttpGet("all")]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Put(int id, [FromBody] Movie updatedMovie)
        {
            bool wasUpdated = await _moviesManager.UpdateMovieByIdAsync(id, updatedMovie);

            if (wasUpdated)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
