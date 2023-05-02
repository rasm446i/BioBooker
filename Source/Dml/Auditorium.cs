using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{

    public class Auditorium
    {
        int auditoriumNumber;
        public List<Seat> seats;

        public Auditorium(List<Seat> seats, int auditoriumNumber)
        {
            seats = new List<Seat>();  
            this.auditoriumNumber = auditoriumNumber;
            
        }

    }
}
