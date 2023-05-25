using BioBooker.Dml;
using System.Collections.Generic;

public class SeatViewModel
{
    public int SeatRows { get; set; }
    public int SeatsPerRow { get; set; }
    public List<SeatReservation> SeatReservations { get; set; }

    public SeatViewModel(int seatRows, int seatsPerRow, List<SeatReservation> seatReservations)
    {
        SeatRows = seatRows;
        SeatsPerRow = seatsPerRow;
        SeatReservations = seatReservations;
    }
}
