using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Dal
{
    public interface IShowingRepository
    {
        Task<bool> AddShowingAsync(Showing showing);
        public Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date);
        Task<bool> InsertReservationByShowingId(SeatReservation reservation);
    }
}