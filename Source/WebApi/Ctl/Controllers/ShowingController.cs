using BioBooker.Dml;
using BioBooker.WebApi.Bll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BioBooker.WebApi.Dto;
using System.Linq;
using System.Security.AccessControl;


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

        //gets all Seats in SeatResevations by showing id
        [HttpGet("{showingId}/reservations")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int showingId)
        {
            List<SeatReservation> seatReservations = await _showingManager.GetAllSeatReservationsByShowingId(showingId);

            if (seatReservations == null || seatReservations.Count == 0)
                {
                    return NotFound();
                }

                return Ok(seatReservations);
        }

        [HttpGet("{showingId}/seatView")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSeatView([FromRoute]int showingId)
        {
            List<SeatReservation> seatReservations = await _showingManager.GetAllSeatReservationsByShowingId(showingId);

            if (seatReservations == null || seatReservations.Count == 0)
            {
                return NotFound();
            }

            SeatViewDto seatViewDto = new SeatViewDto();

               
                seatViewDto.SeatReservations = seatReservations;
                seatViewDto.ShowingId = showingId;
                seatViewDto.SeatRows = seatViewDto.SeatReservations.Max(s => s.SeatRow);
                seatViewDto.SeatsPerRow = seatViewDto.SeatReservations.Max(s => s.SeatNumber);

                return Ok(seatViewDto);
        }





        [HttpPut("{showingId}/reservations")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int showingId, [FromBody] List<SeatReservation> seatReservations)
        {
            IActionResult foundReturn;
            bool wasUpdated = await _showingManager.BookSeatForShowing(seatReservations);

            if (wasUpdated)
            {
                foundReturn = Ok();
            }
            else
            {
                foundReturn = new StatusCodeResult(500);
            }
            return foundReturn;
        }

    }
}
