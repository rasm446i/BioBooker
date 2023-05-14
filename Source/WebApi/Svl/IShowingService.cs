using BioBooker.Dml;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IShowingService
    {
        Task<bool> InsertReservationByShowingId(int showingId, SeatReservation reservation);
        Task<bool> InsertShowingAsync(Showing showing);
    }
}