using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Dal
{
    public interface IShowingRepository
    {
        Task<bool> AddShowingAsync(Showing showing);
        Task<bool> BookSeatForShowing(SeatReservation seatReservation);
        Task<List<SeatReservation>> GetAllSeatReservationByShowingId(int showingId);
        public Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date);
        public Task<List<Showing>> GetShowingsByMovieIdAsync(int movieId);
    }
}