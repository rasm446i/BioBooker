using BioBooker.Dml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BioBooker.WebApi.Ctl.Controllers;
using Microsoft.Extensions.Configuration;
using BioBooker.WebApi.Dal;

namespace BioBooker.WinApp.Svl
{
    public class MoviesService : IMoviesService
    {
        private readonly IServiceConnection _serviceConnection;
        readonly string _serviceBaseUrl = "https://localhost:7011/";
        private readonly MoviesController _controller;
        private readonly IMoviesRepository _movieRepository;

        public MoviesService(IConfiguration configuration)
        {
            _serviceConnection = new ServiceConnection(_serviceBaseUrl);
            _controller = new MoviesController(configuration);

        }

        public Task<bool> DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetMovieByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a movie from the sql database based on the title.
        /// </summary>
        /// <param name="title">The title of the movie to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The retrieved Movie object or null if the movie is not found.</returns>
        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            Movie movie = null;

            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl + "movies?title=" + title;

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
        /// Retrieves all movies from the sql database asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list all of movies.</returns>
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            List<Movie> movies = null;

            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl + "movies/all";

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
        /// Inserts a movie and its corresponding poster into the sql database.
        /// </summary>
        /// <param name="movie">The movie to insert.</param>
        /// <param name="poster">The poster associated with the movie.</param>
        /// <returns>A task representing the asynchronous operation. The task result indicates whether the movie insertion was successful.</returns>
        public async Task<bool> InsertMovieAsync(Movie movie, Poster poster)
        {

            bool changedOk = false;
            if (_serviceConnection != null)
            {
               // _serviceConnection.UseUrl += _serviceConnection.BaseUrl + "movies/";
                string url = _serviceBaseUrl + "movies";

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
                                //await _controller.InsertMovieAsync(movie);
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
        

        public Task<bool> UpdateMovie(int id)
        {
            throw new NotImplementedException();
        }
    }


}

