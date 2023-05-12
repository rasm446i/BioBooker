using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{
    public class SeatReservation
    {
        public int ReservationId { get; set; }
        public int AuditoriumId { get; set; }
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }
        public int ShowingId { get; set; }

        public SeatReservation(int auditoriumId, int seatRow, int seatNumber)
        {
            AuditoriumId = auditoriumId;
            SeatRow = seatRow;
            SeatNumber = seatNumber;
        }
    }
}
