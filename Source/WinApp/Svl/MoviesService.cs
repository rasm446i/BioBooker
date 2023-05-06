using BioBooker.Dml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Http;
using BioBooker.WebApi.Ctl;
using BioBooker.WebApi.Ctl.Controllers;
using Microsoft.Extensions.Configuration;
using BioBooker.WebApi.Dal;
//using System.Configuration;

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
           //_movieRepository = new MoviesRepository(configuration);

        }

        public Task<bool> DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetMovieByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            Movie movie = null;

            if (_serviceConnection != null)
            {
                _serviceConnection.UseUrl += _serviceConnection.BaseUrl + "movies/" + title;

                try
                {
                    HttpResponseMessage? response = await _serviceConnection.CallServiceGet();
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


        public Task<List<Movie>> GetMovies()
        {
            throw new NotImplementedException();
        }

        /*public async Task<bool> InsertMovieAsync(Movie movie)
        {
            return await _movieRepository.AddMovieAsync(movie);
        }
        */
        
        public async Task<bool> InsertMovieAsync(Movie movie, Poster poster)
        {

            bool changedOk = false;
            if (_serviceConnection != null)
            {
                _serviceConnection.UseUrl += _serviceConnection.BaseUrl + "movies/";

                if (movie != null)
                {
                    try
                    {
                        var json = JsonConvert.SerializeObject(movie);
                        var postData = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage? response = await _serviceConnection.CallServicePost(postData);
                        if (response != null)
                        {

                            if (response.IsSuccessStatusCode)
                            {
                                changedOk = true;
                                await _controller.InsertMovieAsync(movie);
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

