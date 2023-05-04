using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{

    public class Auditorium
    {
        public int AuditoriumNumber { get; set; }
        public List<Seat> seats;

        public Auditorium()
        {
            
        }
        public Auditorium(List<Seat> seats, int auditoriumNumber)
        {
            seats = new List<Seat>();  
            AuditoriumNumber = auditoriumNumber;
            
        }

    }
}
