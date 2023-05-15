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

    public class ShowingController: ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IShowingManager _showingManager;

        public ShowingController(IConfiguration inConfiguration)
        {
            _configuration = inConfiguration;
            _showingManager = new ShowingManager(_configuration);
        }

        [HttpPost]
        [AllowAnonymous]
        // Inserts a new showing into the database using the _showingManager.InsertShowingAsync() method.
        // Returns Ok() if the insertion was successful, otherwise returns a StatusCodeResult with code 500.
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

        [HttpGet]
        [AllowAnonymous]
        // Retrieves showings from the database based on the specified auditorium ID and date using the GetShowingsAsync() method in Showing.
        // Returns Ok(showings) if showings are found, otherwise returns NotFound().
        public async Task<IActionResult> Get(int auditoriumId, DateTime date)
        {
            List<Showing> showings = await _showingManager.GetShowingsByAuditoriumIdAndDateAsync(auditoriumId, date);

            if (showings == null)
            {
                return NotFound();
            }

            return Ok(showings);
        }



    }
}
