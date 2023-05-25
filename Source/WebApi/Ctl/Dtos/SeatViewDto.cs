using BioBooker.Dml;
using System.Collections.Generic;


namespace BioBooker.WebApi.Dto
{

    class SeatViewDto
    {
        public int AuditoriumId { get; set; }
        public int SeatRows { get; set; }
        public int SeatsPerRow { get; set; }
        public int ShowingId { get; set; }
        public List<SeatReservation> SeatReservations { get; set; }

    }

}