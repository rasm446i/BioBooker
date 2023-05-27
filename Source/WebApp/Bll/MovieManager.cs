using BioBooker.Dml;
using BioBooker.WebApp.Svl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApp.Bll
{
    public class MovieManager : IMovieManager
    {
        private readonly MovieServiceApi _movieServiceApi;

        /// <summary>
        /// Initializes a new instance of the MovieManager class.
        /// </summary>
        public MovieManager()
        {
            _movieServiceApi = new MovieServiceApi();
        }

        /// <summary>
        /// Retrieves a list of movies from the MovieServiceApi.
        /// </summary>
        /// <returns>A task that returns a list of movies.</returns>
        public async Task<List<Movie>> GetMovies()
        {
            return await _movieServiceApi.GetMovies();
        }

        /// <summary>
        /// Retrieves a list of showings for a specific movie ID from the MovieServiceApi.
        /// </summary>
        /// <param name="movieId">The ID of the movie.</param>
        /// <returns>A task that returns a list of showings.</returns>
        public async Task<List<Showing>> GetShowingsByMovieIdAsync(int movieId)
        {

            return await _movieServiceApi.GetShowingsByMovieIdAsync(movieId);
        }


    }
}
