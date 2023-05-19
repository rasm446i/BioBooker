using Microsoft.AspNetCore.Mvc;
using BioBooker.WebApi.Bll;
using Microsoft.Extensions.Configuration;
using BioBooker.Dml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;

namespace BioBooker.WebApi.Ctl.Controllers
{
    [Route("showings")]
    [ApiController]
    public class ShowingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IShowingManager _showingManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowingController"/> class.
        /// </summary>
        /// <param name="inConfiguration">The configuration object.</param>
        public ShowingController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _showingManager = new ShowingManager(_configuration);
        }

        /// <summary>
        /// Inserts a new showing into the database.
        /// </summary>
        /// <param name="showing">The showing to insert.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] Showing showing)
        {
            IActionResult inserted;
            bool wasOk = await _showingManager.InsertShowingAsync(showing);
            if (wasOk)
            {
                inserted = Ok();
            }
            else
            {
                inserted = new StatusCodeResult(500);
            }
            return inserted;
        }

        /// <summary>
        /// Inserts a new seat reservation for a showing.
        /// </summary>
        /// <param name="reservation">The seat reservation to insert.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost("{showingId}/reservations")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] SeatReservation reservation)
        {
            bool reserved = await _showingManager.InsertReservationByShowingId(reservation);

            if (reserved)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retrieves showings from the database based on the specified auditorium ID and date.
        /// </summary>
        /// <param name="auditoriumId">The ID of the auditorium.</param>
        /// <param name="date">The date of the showings.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int auditoriumId, DateTime date)
        {
            List<Showing> showings = await _showingManager.GetShowingsByAuditoriumIdAndDateAsync(auditoriumId, date);

            if (showings == null)
            {
                return NotFound();
            }

            return Ok(showings);
        }
<<<<<<< Updated upstream
        //This is just for testing
        [HttpGet("{id}/reservations")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            List<SeatReservation> seatReservations = new List<SeatReservation>();
            int reservationId = 1;
            int auditoriumId = 1;
            int showingId = 1;
            int? customerId = null;

            int numRows = 5;
            int numSeatsPerRow = 7;

            for (int row = 1; row <= numRows; row++)
            {
                for (int seatNumber = 1; seatNumber <= numSeatsPerRow; seatNumber++)
                {
                    SeatReservation reservation = new SeatReservation(auditoriumId, row, seatNumber, showingId, customerId);
                    reservation.ReservationId = reservationId++;
                    seatReservations.Add(reservation);
                }
            }

            return Ok(seatReservations);
        }



=======

        [HttpPut("{showingId}/reservations")]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] SeatReservation seatReservation, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            IActionResult foundReturn;
            bool wasUpdated = await _showingManager.BookSeatForShowing(seatReservation, date, startTime, endTime);
            if(wasUpdated)
            {
                foundReturn = Ok();
            } 
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }
>>>>>>> Stashed changes
    }
}
