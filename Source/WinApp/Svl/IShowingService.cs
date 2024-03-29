using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public interface IShowingService
    {
        Task<bool> InsertShowingAsync(Showing showing);
        Task<bool> InsertReservationAsync(SeatReservation reservation);
        Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date);
    }
}