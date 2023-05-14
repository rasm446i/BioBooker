using BioBooker.Dml;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Bll
{
    public interface IShowingManager
    {

        Task<bool> InsertShowingAsync(Showing showing);

        public Task<bool> InsertReservationByShowingId(int showingId, SeatReservation reservation);
    }
}