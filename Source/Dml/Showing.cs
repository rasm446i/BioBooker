using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{


    public class Showing
    {
        public Movie Movie { get; set; }

        public List<Seat> Seats { get; set; }


        //Constructor
        public Showing()
        {

        }
        //Constructor
        public Showing(Movie movie, List<Seat> seats) 
        { 
            Movie = movie;
            Seats = seats;
        }


        // loops through the list of seats until it finds the specific seat in that specific seatRow
        // then tries too booked the seat
        public bool BookSeat(int rowNumber, int seatNumber)
        {
            Seat seat;
            bool wasBooked = false;
            foreach (Seat s in Seats)
            {
                if (s.SeatRow == rowNumber && s.SeatNumber == seatNumber)
                {
                    seat = s;
                    if (seat != null && seat.IsAvailable)
                    {
                        seat.IsAvailable = false;
                        wasBooked= true;
                        break;
                    }
                }
            }

            return wasBooked;
        }

    }
}
