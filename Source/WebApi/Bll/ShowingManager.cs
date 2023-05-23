using BioBooker.Dml;
using BioBooker.WebApi.Svl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Bll
{
    public class ShowingManager: IShowingManager
    {
        private readonly IShowingService _showingService;

        //Constructor
        public ShowingManager(IConfiguration inConfiguration)
        {
            _showingService = new ShowingService(inConfiguration);
        }

        public async Task<bool> InsertShowingAsync(Showing showing)
        {
            return await _showingService.InsertShowingAsync(showing);
        }

        public async Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date)
        {
            return await _showingService.GetShowingsByAuditoriumIdAndDateAsync(auditoriumId, date);
        }

        public async Task<bool> BookSeatForShowing(SeatReservation seatReservation)
        {
            return await _showingService.BookSeatForShowing(seatReservation);
        }

        public async Task<List<SeatReservation>> GetAllSeatReservationsByShowingId(int showingId)
        {
            return await _showingService.GetAllSeatReservationByShowingId(showingId);
        }
    }
}
