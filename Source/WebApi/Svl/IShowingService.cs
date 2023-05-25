using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IShowingService
    {
        Task<bool> BookSeatForShowing(SeatReservation seatReservation);
        Task<List<SeatReservation>> GetAllSeatReservationByShowingId(int showingId);
        public Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date);
        Task<bool> InsertShowingAsync(Showing showing);
    }
}