using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApp.Svl
{
    public interface IShowingServiceApi
    {

        public Task<SeatViewModel> GetAllSeatReservationsByShowingId(int showingId);
        public Task<bool> BookSeatsAsync(int showingId, List<SeatReservation> seatReservation);
    }
}
