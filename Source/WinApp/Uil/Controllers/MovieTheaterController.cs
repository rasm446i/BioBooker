using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Uil.Controllers
{
    public class MovieTheaterController
    {
       private MovieTheaterBusinessController movieTheaterBusinessController;
       public MovieTheaterController()
        {
            movieTheaterBusinessController= new MovieTheaterBusinessController();
        }

        public async Task CreateSeatsAndMovieTheaterFromUserInput(string movieTheaterName, int amountOfRows, int seatsPerRow)
        {
            List<Seat> generatedSeats = GetGeneratedSeats(amountOfRows, seatsPerRow);
            await movieTheaterBusinessController.CreateMovieTheater(movieTheaterName, generatedSeats);
        }

        public static List<Seat> GetGeneratedSeats(int amountOfRows, int seatsPerRow)
        {
            List<Seat> seats = new List<Seat>();
            for (int rowNum = 1; rowNum <= amountOfRows; rowNum++)
            {
                for (int seatNum = 1; seatNum <= seatsPerRow; seatNum++)
                {
                    seats.Add(new Seat(rowNum, seatNum));
                }
            }
            return seats;
        }


    }
    
}
