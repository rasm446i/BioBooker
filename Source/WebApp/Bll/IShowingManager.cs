using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApp.Bll
{
    public interface IShowingManager
    {

        public Task<SeatViewModel> GetAllSeatReservationByShowingId(int showingId);
        public Task<bool> BookSeatsAsync(int showingId, List<SeatReservation> seatReservation);

    }
}
