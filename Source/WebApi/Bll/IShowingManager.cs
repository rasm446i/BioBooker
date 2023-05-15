using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Bll
{
    public interface IShowingManager
    {

        Task<bool> InsertShowingAsync(Showing showing);

        public Task<bool> InsertReservationByShowingId(SeatReservation reservation);

        public Task<List<Showing>> GetAllShowingsAsync();
    }
}