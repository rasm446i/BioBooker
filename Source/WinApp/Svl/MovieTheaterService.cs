using BioBooker.Dml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

            // Check if the service base URL and the movie theater object are not null
            if (_serviceBaseUrl != null && movieTheater != null)
            {
                try
                {
                    // Serialize the movie theater object to JSON
                    var json = JsonConvert.SerializeObject(movieTheater);

                    // Create a StringContent object with the serialized JSON data
                    var postData = new StringContent(json, Encoding.UTF8, "application/json");

                    // Call the service asynchronously and perform a POST request
                    var response = await _serviceConnection.CallServicePost(_serviceBaseUrl, postData);

                    // Check if the response is not null and if the operation was successful
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        wasSaved = true; // The movie theater was successfully saved
                    }
                    else
                    {
                        wasSaved = false; // The movie theater was not saved
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }

            // Return the result indicating whether the movie theater was saved or not
            return wasSaved;
        }

        public async Task<MovieTheater> GetMovieTheaterAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<List<MovieTheater>> GetMovieTheatersAsync()
        {
            List<MovieTheater> movieTheaters = null;

            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl;

                try
                {
                    HttpResponseMessage? response = await _serviceConnection.CallServiceGet(url);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        movieTheaters = JsonConvert.DeserializeObject<List<MovieTheater>>(json);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            return movieTheaters;
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

        public async Task<bool> InsertAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasSaved = false;
            string url = $"{_serviceBaseUrl}/{movieTheaterId}/auditoriums";

                    // Check for valid input
            if (_serviceBaseUrl != null && newAuditorium != null && movieTheaterId > 0)
            {
                try
                {
                    // Serialize the auditorium object to JSON
                    var json = JsonConvert.SerializeObject(newAuditorium);

                    // Create the HTTP content for the POST request
                    var postData = new StringContent(json, Encoding.UTF8, "application/json");

                    // Call the service to insert the auditorium
                    var response = await _serviceConnection.CallServicePost(url, postData);

                    // Check if the response indicates a successful creation
                    wasSaved = response != null && response.StatusCode == HttpStatusCode.Created;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }

            // Return the result indicating whether the auditorium was saved successfully
            return wasSaved;
        }


    }

}
