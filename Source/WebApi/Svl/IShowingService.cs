using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IShowingService
    {

        public Task<List<Showing>> GetAllShowingsAsync();
        Task<bool> InsertReservationByShowingId(SeatReservation reservation);
        Task<bool> InsertShowingAsync(Showing showing);
    }
}