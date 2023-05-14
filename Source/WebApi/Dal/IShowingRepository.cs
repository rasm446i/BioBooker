using BioBooker.Dml;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Dal
{
    public interface IShowingRepository
    {
        Task<bool> AddShowingAsync(Showing showing);
        Task<bool> InsertReservationByShowingId(SeatReservation reservation);
    }
}