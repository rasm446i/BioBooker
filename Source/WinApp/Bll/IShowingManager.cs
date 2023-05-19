using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BioBooker.WinApp.Bll
{
    public interface IShowingManager
    {
        public Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date);
        public Task<bool> CreateAndInsertShowingAsync(Showing showing);
        public Task<bool> ShowingExists(int auditoriumId, TimeSpan startTime, TimeSpan endTime, DateTime date);
        public Task<bool> InsertReservationByShowingIdAsync(SeatReservation reservation);

    }
}