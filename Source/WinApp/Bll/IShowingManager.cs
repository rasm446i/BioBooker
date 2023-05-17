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
        public Task<Showing> CreateShowing(Showing showing);

        public Task<bool> InsertReservationByShowingIdAsync(SeatReservation reservation);

    }
}