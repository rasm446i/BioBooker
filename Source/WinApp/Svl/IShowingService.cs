using BioBooker.Dml;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public interface IShowingService
    {
        Task<bool> InsertShowingAsync(Showing showing);
        Task<bool> InsertReservationAsync(int showingId, SeatReservation reservation);
    }
}