using BioBooker.Dml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BioBooker.WinApp.Svl
{
    public class MovieTheaterService : IMovieTheaterService
    {
        readonly IServiceConnection _serviceConnection;
        readonly string _serviceBaseUrl = "https://localhost:7011/api/movieTheaters";

        public MovieTheaterService() 
            {
            _serviceConnection = new ServiceConnection(_serviceBaseUrl);
            }
        public async Task<bool> InsertMovieTheaterAsync(MovieTheater movieTheater)
        {
            bool wasSaved = false;

            if (_serviceBaseUrl != null && movieTheater != null)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(movieTheater);
                    var postData = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await _serviceConnection.CallServicePost(_serviceBaseUrl, postData);

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        wasSaved = true;
                    }
                    else
                    {
                        wasSaved = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }

            return wasSaved;
        }





        public async Task<MovieTheater> GetMovieTheaterAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Auditorium>> GetAuditoriumsAsync(int movieTheaterId)
        {

            throw new NotImplementedException();
        }

        public async Task<bool> UpdateMovieTheaterAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteMovieTheaterAsync()
        {
            throw new NotImplementedException();
        }
    }
}