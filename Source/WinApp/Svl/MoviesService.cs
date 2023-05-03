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
//using System.Configuration;

namespace BioBooker.WinApp.Svl
{
    public class MoviesService : IMoviesService
    {
        private readonly IServiceConnection _serviceConnection;
        readonly string _serviceBaseUrl = "https://localhost:7011/";

        public MoviesService() 
        {
            _serviceConnection = new ServiceConnection(_serviceBaseUrl);
        }

        public Task<bool> DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetMovieByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertMovieAsync(Movie movie)
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

                        if (response.IsSuccessStatusCode)
                        {
                            changedOk = true;
                        }
                        else
                        {
                            changedOk = false;
                        }
                    
                    }
                    catch (HttpResponseException ex)
                    {
                        throw new HttpResponseException(System.Net.HttpStatusCode.ServiceUnavailable);
                        changedOk = false;
                    }
                }
            }
            return changedOk;
        }

        public Task<bool> InsertMovieTheaterAsync(Movie movieToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMovie(int id)
        {
            throw new NotImplementedException();
        }
    }

   
    }
}
