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

        public async Task PassListOfSeatsToAuditoriumCreateAuditorium(string movieTheaterName, List<Seat> seats, int amountOfRows, int seatsPerRow)
        {
            List<Seat> generatedSeats = GetGeneratedSeats(amountOfRows, seatsPerRow);
           await movieTheaterBusinessController.CreateMovieTheater(movieTheaterName, generatedSeats);
        }

        public static List<Seat> GetGeneratedSeats(int amountOfRows, int seatsPerRow)
        {
            List<Seat> seats = new List<Seat>();
            for (int i = 1; i <= amountOfRows; i++)
            {
                for (int j = 1; j <= seatsPerRow; j++)
                {
                    seats.Add(new Seat(i, j));
                }
            }
            return seats;
        }


    }
    
}
