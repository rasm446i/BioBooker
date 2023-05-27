using BioBooker.Dml;
using BioBooker.WebApp.Svl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApp.Bll
{
    public class ShowingManager : IShowingManager
    {
        private readonly ShowingServiceApi _showingServiceApi;

        /// <summary>
        /// Initializes a new instance of the ShowingManager class.
        /// </summary>
        public ShowingManager()
        {
            _showingServiceApi = new ShowingServiceApi();
        }

        /// <summary>
        /// Retrieves all seat reservations for a specific showing ID from the ShowingServiceApi.
        /// </summary>
        /// <param name="showingId">The ID of the showing.</param>
        /// <returns>A task that returns a SeatViewModel containing seat reservations.</returns>
        public async Task<SeatViewModel> GetAllSeatReservationByShowingId(int showingId)
        {
            return await _showingServiceApi.GetAllSeatReservationsByShowingId(showingId);
        }

        /// <summary>
        /// Books seats for a specific showing ID and seat reservations using the ShowingServiceApi.
        /// </summary>
        /// <param name="showingId">The ID of the showing.</param>
        /// <param name="seatReservation">The list of seat reservations to be booked.</param>
        /// <returns>A task that returns a boolean indicating the success of the booking.</returns>
        public async Task<bool> BookSeatsAsync(int showingId, List<SeatReservation> seatReservation)
        {
            return await _showingServiceApi.BookSeatsAsync(showingId, seatReservation);
        }

    }
}
