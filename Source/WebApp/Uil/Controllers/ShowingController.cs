using BioBooker.Dml;
using BioBooker.WebApp.Bll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApp.Uil.Controllers
{
    public class ShowingController : Controller
    {
        private readonly ShowingManager _showingManager;

        public ShowingController()
        {
            _showingManager = new ShowingManager();
        }

        /// <summary>
        /// Displays the index view for a specific showing, including seat reservations.
        /// </summary>
        /// <param name="showingId">The ID of the showing.</param>
        /// <returns>A task representing the index view with seat reservations.</returns>
        public async Task<IActionResult> Index(int showingId)
        {
            SeatViewModel seatViewModel = await _showingManager.GetAllSeatReservationByShowingId(showingId);

            return View(seatViewModel);
        }

        /// <summary>
        /// Books the selected seats for a showing and redirects to the payment view.
        /// </summary>
        /// <param name="showingId">The ID of the showing.</param>
        /// <param name="selectedSeats">The list of seat reservations to be booked.</param>
        /// <returns>A task that redirects to the payment view.</returns>
        public async Task<RedirectToActionResult> BookSeats(int showingId, List<SeatReservation> selectedSeats)
        {
            var seatsToBeBooked = new List<SeatReservation>();
            var customerId = int.Parse(Request.Form["CustomerId"]);

            foreach (var seat in selectedSeats)
            {
                // Iterate through selected seats and add them to seatsToBeBooked list
                if (seat.SeatRow != 0)
                {
                    seat.CustomerId = customerId;
                    seatsToBeBooked.Add(seat);

                }
            }
            if (seatsToBeBooked.Count > 0)
            {
                await _showingManager.BookSeatsAsync(showingId, seatsToBeBooked);
                return RedirectToAction("PaymentView");
            }
            return null;
        }

        /// <summary>
        /// Displays the payment view.
        /// </summary>
        /// <returns>A task representing the payment view.</returns>
        public async Task<IActionResult> PaymentView()
        {

            return View();
        }

    }
}
