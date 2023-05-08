using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{

    public class Auditorium
    {
        public int MovieTheaterId { get; set; }
        public int AuditoriumId { get; set; }
        public List<Seat> Seats { get; set; }

        public Auditorium()
        {
            
        }
        public Auditorium(List<Seat> seats)
        {
            Seats = new List<Seat>();  
            
        }

    }
}
