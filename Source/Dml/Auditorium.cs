using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{

    public class Auditorium
    {
        public int AuditoriumId { get; set; }
        public List<Seat> seats { get; set; }

        public Auditorium()
        {
            
        }
        public Auditorium(List<Seat> seats, int auditoriumNumber)
        {
            seats = new List<Seat>();  
            AuditoriumId = auditoriumNumber;
            
        }

    }
}
