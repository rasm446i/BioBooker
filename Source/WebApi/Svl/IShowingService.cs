using BioBooker.Dml;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IShowingService
    {
        Task<bool> InsertReservationByShowingId(SeatReservation reservation);
        Task<bool> InsertShowingAsync(Showing showing);
    }
}