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
        readonly string _serviceBaseUrl = "https://localhost:7261/api/movieTheaters/";

        public MovieTheaterService() 
            {
            _serviceConnection = new ServiceConnection(_serviceBaseUrl);
            }
        public async Task<bool> InsertMovieTheaterAsync(MovieTheater movieTheater)
        {
            bool wasSaved = false;
            if(_serviceConnection != null)
            {
                _serviceConnection.UseUrl += _serviceConnection.BaseUrl + "movieTheaters/";

                if(movieTheater != null)
                {
                    try
                    {
                        var json = JsonConvert.SerializeObject(movieTheater);
                        var postData = new StringContent(json,Encoding.UTF8, "application/json");

                        HttpResponseMessage? response = await _serviceConnection.CallServicePost(postData);

                        if(response != null)
                        {
                            wasSaved = true;
                        } else
                        {
                            wasSaved = false;
                        }
                    }
                    catch (HttpResponseException ex)
                    {
                        throw new HttpResponseException(System.Net.HttpStatusCode.ServiceUnavailable);
                    }
                }

            }
            return wasSaved;
            
        }

        public async Task<MovieTheater> GetMovieTheaterAsync()
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
