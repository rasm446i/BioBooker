using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{
    public class Seat
    {
      public bool IsAvailable { get; set; }
      public int SeatNumber { get; set; }
      public int SeatRow { get; set; }

       public Seat() { }
        public Seat(bool isAvailable, int seatNumber, int seatRow)
        { 
            IsAvailable = isAvailable;
            SeatNumber = seatNumber;
            SeatRow = seatRow;
        }
    }
}
