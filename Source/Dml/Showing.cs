using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{


    public class Showing
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int AuditoriumId { get; set; }
        public int MovieId { get; set; }
        public List<SeatReservation> SeatReservations { get; set; }

        public Showing(DateTime date, TimeSpan startTime, TimeSpan endTime, int auditoriumId, int movieId)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            AuditoriumId = auditoriumId;
            MovieId = movieId;
            SeatReservations = new List<SeatReservation>();
        }
    }
}
