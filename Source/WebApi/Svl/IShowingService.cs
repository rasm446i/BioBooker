using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IShowingService
    {
        Task<bool> BookSeatForShowing(SeatReservation seatReservation, DateTime date, TimeSpan startTime, TimeSpan endTime);
        public Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date);
        Task<bool> InsertReservationByShowingId(SeatReservation reservation);
        Task<bool> InsertShowingAsync(Showing showing);
    }
}