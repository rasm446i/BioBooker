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
    public class ShowingServiceApi : IShowingServiceApi
    {
        readonly string restUrl = "https://localhost:7011/api/showings/";
        readonly HttpClient _client;

        public ShowingServiceApi()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// Retrieves all seat reservations for a specific showing by its ID.
        /// </summary>
        /// <param name="showingId">The ID of the showing.</param>
        /// <returns>The SeatViewModel containing seat reservations for the showing.</returns>
        public async Task<SeatViewModel> GetAllSeatReservationsByShowingId(int showingId)
        {
            SeatViewModel seatViewModel;

            string useRestUrl = restUrl + $"{showingId}/seatView";
            var uri = new Uri(useRestUrl);

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    seatViewModel = JsonConvert.DeserializeObject<SeatViewModel>(content);
                }
                else
                {
                    seatViewModel = null;
                }
            }
            catch
            {
                throw;
            }

            return seatViewModel;
        }

        /// <summary>
        /// Books seats for a specific showing.
        /// </summary>
        /// <param name="showingId">The ID of the showing.</param>
        /// <param name="seatReservation">The list of seat reservations to book.</param>
        /// <returns>True if the seats were successfully booked; otherwise, false.</returns>
        public async Task<bool> BookSeatsAsync(int showingId, List<SeatReservation> seatReservation)
        {
            try
            {
                string useRestUrl = restUrl + $"{showingId}/reservations";
                var uri = new Uri(useRestUrl);

                // Convert seatReservation list to JSON
                string json = JsonConvert.SerializeObject(seatReservation);

                // Create the HTTP content with JSON data
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                // Create the HTTP client
                using (var httpClient = new HttpClient())
                {
                    // Send PUT request to the API
                    HttpResponseMessage response = await httpClient.PutAsync(uri, content);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Return true if seats were successfully booked
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the request
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

    }
}
