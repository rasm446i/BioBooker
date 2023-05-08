using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{
    public class Seat
    {
      public bool IsAvailable { get; set; } = true;
      public int SeatNumber { get; set; }
      public int SeatRow { get; set; }
 
       
       public Seat() { }
        public Seat(int seatNumber, int seatRow)
        { 
            SeatNumber = seatNumber;
            SeatRow = seatRow;
        }
    }
}
