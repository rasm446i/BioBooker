using BioBooker.Dml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApp.Svl
{
    public class MovieServiceApi : IMovieServiceApi
    {
        readonly string restUrl = "https://localhost:7011/api/movies";
        readonly HttpClient _client;

        public MovieServiceApi()
        {
            _client = new HttpClient();
        }


        /// <summary>
        /// Retrieves a list of movies.
        /// </summary>
        /// <returns>The list of movies.</returns>
        public async Task<List<Movie>> GetMovies()
        {
            List<Movie> retrievedMovies;

            // Create URI
            string useRestUrl = restUrl;
            var uri = new Uri(useRestUrl);

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    retrievedMovies = JsonConvert.DeserializeObject<List<Movie>>(content);
                }
                else
                {
                    retrievedMovies = null;
                }
            }
            catch
            {
                throw;
            }

            return retrievedMovies;
        }

        /// <summary>
        /// Retrieves a list of showings for a specific movie.
        /// </summary>
        /// <param name="movieId">The ID of the movie.</param>
        /// <returns>The list of showings.</returns>
        public async Task<List<Showing>> GetShowingsByMovieIdAsync(int movieId)
        {
            List<Showing> retrievedShowings;

            string useRestUrl = restUrl + $"/{movieId}/showings";
            var uri = new Uri(useRestUrl);

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    retrievedShowings = JsonConvert.DeserializeObject<List<Showing>>(content);
                }
                else
                {
                    retrievedShowings = null;
                }
            }
            catch
            {
                throw;
            }

            return retrievedShowings;
        }

    }
}
