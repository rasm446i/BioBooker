using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Bll
{
    public interface IShowingManager
    {

        Task<bool> InsertShowingAsync(Showing showing);

        public Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date);
        Task<bool> BookSeatForShowing(List<SeatReservation> seatReservations);
        Task<List<SeatReservation>> GetAllSeatReservationsByShowingId(int showingId);
    }
}