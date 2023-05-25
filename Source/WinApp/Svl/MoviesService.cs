using BioBooker.Dml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BioBooker.WebApi.Ctl.Controllers;
using Microsoft.Extensions.Configuration;

namespace BioBooker.WinApp.Svl
{

    public class MoviesService : IMoviesService
    {
        private readonly IServiceConnection _serviceConnection;
        readonly string _serviceBaseUrl = "https://localhost:7011/api/movies";
        private readonly MoviesController _controller;

        public MoviesService(IConfiguration configuration)
        {
            _serviceConnection = new ServiceConnection(_serviceBaseUrl);
            _controller = new MoviesController(configuration);
        }

        /// <summary>
        /// Deletes a movie from the SQL database by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        /// <returns>A boolean value indicating whether the movie deletion was successful.</returns>
        public async Task<bool> DeleteMovieByIdAsync(int id)
        {
            bool deleted = false;

            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl + "/" + id;

                try
                {
                    HttpResponseMessage? response = await _serviceConnection.CallServiceDelete(url, id);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        deleted = true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return deleted;
        }

        /// <summary>
        /// Retrieves a movie from the SQL database based on the title.
        /// </summary>
        /// <param name="title">The title of the movie to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The retrieved Movie object or null if the movie is not found.</returns>
        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            Movie movie = null;

            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl + "/movies?title=" + title;

                try
                {
                    HttpResponseMessage? response = await _serviceConnection.CallServiceGet(url);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        movie = JsonConvert.DeserializeObject<Movie>(json);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return movie;
        }

        /// <summary>
        /// Retrieves a movie from the SQL database based on the ID.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The retrieved Movie object or null if the movie is not found.</returns>
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            Movie movie = null;

            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl + "/id/" + id;

                try
                {
                    HttpResponseMessage? response = await _serviceConnection.CallServiceGet(url);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        movie = JsonConvert.DeserializeObject<Movie>(json);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return movie;
        }

        /// <summary>
        /// Retrieves all movies from the SQL database asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of all movies.</returns>
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            List<Movie> movies = null;

            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl;

                try
                {
                    HttpResponseMessage? response = await _serviceConnection.CallServiceGet(url);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return movies;
        }

        /// <summary>
        /// Inserts a movie and its corresponding poster into the SQL database.
        /// </summary>
        /// <param name="movie">The movie to insert.</param>
        /// <param name="poster">The poster associated with the movie.</param>
        /// <returns>A task representing the asynchronous operation. The task result indicates whether the movie insertion was successful.</returns>
        public async Task<bool> InsertMovieAsync(Movie movie, Poster poster)
        {
            bool changedOk = false;
            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl;

                if (movie != null)
                {
                    try
                    {
                        var json = JsonConvert.SerializeObject(movie);
                        var postData = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage? response = await _serviceConnection.CallServicePost(url, postData);
                        if (response != null)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                changedOk = true;
                            }
                            else
                            {
                                changedOk = false;
                            }
                        }
                    }
                    catch
                    {
                        changedOk = false;
                    }
                }
            }
            return changedOk;
        }

        /// <summary>
        /// Updates a movie in the SQL database by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="updatedMovie">The updated movie object.</param>
        /// <returns>A boolean value indicating whether the movie update was successful.</returns>
        public async Task<bool> UpdateMovieByIdAsync(int id, Movie updatedMovie)
        {
            bool updated = false;

            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl + "/" + id;

                if (updatedMovie != null)
                {
                    try
                    {
                        var json = JsonConvert.SerializeObject(updatedMovie);
                        var putData = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage? response = await _serviceConnection.CallServicePut(url, putData);
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            updated = true;
                        }
                    }
                    catch
                    {
                        updated = false;
                    }
                }
            }

            return updated;
        }
    }
}
