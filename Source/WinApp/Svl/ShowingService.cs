using BioBooker.Dml;
using BioBooker.WebApi.Ctl.Controllers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Retrieves a list of showings for a specific auditorium and date from the web API.
        /// </summary>
        /// <param name="auditoriumId">The ID of the auditorium.</param>
        /// <param name="date">The date for which showings are to be retrieved.</param>
        /// <returns>A task representing the asynchronous operation. The list of showings for the specified auditorium and date.</returns>
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


        /// <summary>
        /// Inserts a seat reservation into the database for a specific showing.
        /// </summary>
        /// <param name="reservation">The seat reservation to insert.</param>
        /// <returns>A task representing the asynchronous operation. A boolean value indicating whether the reservation insertion was successful.</returns>
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

                        HttpResponseMessage response = await _serviceConnection.CallServicePut(url, postData);
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


        /// <summary>
        /// Inserts a showing into the database.
        /// </summary>
        /// <param name="showing">The showing to insert.</param>
        /// <returns>A task representing the asynchronous operation. A boolean value indicating whether the showing insertion was successful.</returns>
        public async Task<bool> InsertShowingAsync(Showing showing)
        {

            bool changedOk = false;
            if (_serviceConnection != null)
            {
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
