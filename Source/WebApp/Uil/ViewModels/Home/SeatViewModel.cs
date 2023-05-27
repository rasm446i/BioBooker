using BioBooker.Dml;
using System.Collections.Generic;

namespace BioBooker.WebApp.Uil.ViewModels.Home
{
    public class SeatViewModel
    {

        public int SeatRows { get; set; }
        public int SeatsPerRow { get; set; }
        public List<SeatReservation> SeatReservations { get; set; }
        public int ShowingId { get; set; }


        public SeatViewModel(int seatRows, int seatsPerRow, List<SeatReservation> seatReservations, int showingId)
        {
            ShowingId = showingId;
            SeatRows = seatRows;
            SeatsPerRow = seatsPerRow;
            SeatReservations = seatReservations;
        }





    }
}
