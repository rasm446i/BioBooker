using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Dal
{
    public interface IShowingRepository
    {
        Task<bool> AddShowingAsync(Showing showing);
        public Task<List<Showing>> GetAllShowingsAsync();
        Task<bool> InsertReservationByShowingId(SeatReservation reservation);
    }
}