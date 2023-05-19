using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{
    public class SeatReservation
    {
        public byte[] Version { get; set; }
        public int ReservationId { get; set; }
        public int AuditoriumId { get; set; }
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }
        public int ShowingId { get; set; }
        public int? CustomerId { get; set; }

        public SeatReservation(int auditoriumId, int seatRow, int seatNumber, int showingId, int? customerId)
        {
            AuditoriumId = auditoriumId;
            SeatRow = seatRow;
            SeatNumber = seatNumber;
            ShowingId = showingId;
            CustomerId = customerId;    
        }
    }
}
