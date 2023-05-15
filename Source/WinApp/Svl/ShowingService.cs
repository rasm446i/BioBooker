using BioBooker.Dml;
using BioBooker.WebApi.Ctl.Controllers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public class ShowingService : IShowingService
    {
        private readonly IServiceConnection _serviceConnection;
        readonly string _serviceBaseUrl = "https://localhost:7011/";
        private readonly ShowingController _controller;

        public ShowingService(IConfiguration configuration)
        {
            _serviceConnection = new ServiceConnection(_serviceBaseUrl);
            _controller = new ShowingController(configuration);
        }

        public async Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date)
        {
            List<Showing> showings = null;

            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl + "showings?auditoriumId=" + auditoriumId + "&date=" + date.ToString("yyyy-MM-dd");

                try
                {
                    HttpResponseMessage? response = await _serviceConnection.CallServiceGet(url);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        showings = JsonConvert.DeserializeObject<List<Showing>>(json);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return showings;
        }


        public async Task<bool> InsertReservationAsync(SeatReservation reservation)
        {
            int showingId = reservation.ShowingId;
            bool reservedOk = false;
            if (_serviceConnection != null)
            {
                string url = _serviceBaseUrl + $"showings/{showingId}/reservations";

                if (reservation != null)
                {
                    try
                    {
                        var json = JsonConvert.SerializeObject(reservation);
                        var postData = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await _serviceConnection.CallServicePost(url, postData);
                        if (response.IsSuccessStatusCode)
                        {
                            reservedOk = true;
                        }
                        else
                        {
                            reservedOk = false;
                        }
                    }
                    catch
                    {
                        reservedOk = false;
                    }
                }
            }
            return reservedOk;
        }


        public async Task<bool> InsertShowingAsync(Showing showing)
        {

            bool changedOk = false;
            if (_serviceConnection != null)
            {
                // _serviceConnection.UseUrl += _serviceConnection.BaseUrl + "movies/";
                string url = _serviceBaseUrl + "showings";

                if (showing != null)
                {
                    try
                    {
                        var json = JsonConvert.SerializeObject(showing);
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
    }
}
