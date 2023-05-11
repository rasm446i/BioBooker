using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Uil.Controllers
{
    public class MovieTheaterController
    {
        private MovieTheaterBusinessController movieTheaterBusinessController;
        public MovieTheaterController()
        {
            movieTheaterBusinessController = new MovieTheaterBusinessController();
        }

        public async Task<bool> CreateSeatsAndMovieTheaterFromUserInput(string movieTheaterName, int amountOfRows, int seatsPerRow)
        {
            // Generate seats based on the provided amount of rows and seats per row
            List<Seat> generatedSeats = GetGeneratedSeats(amountOfRows, seatsPerRow);

            // Create a movie theater with the provided name and generated seats
            bool wasInserted = await movieTheaterBusinessController.CreateMovieTheater(movieTheaterName, generatedSeats);

            // Return the result indicating whether the movie theater and seats were successfully created and inserted
            return wasInserted;
        }


        public static List<Seat> GetGeneratedSeats(int amountOfRows, int seatsPerRow)
        {
            // Create a new list to store the generated seats
            List<Seat> seats = new List<Seat>();

            // Iterate through each row
            for (int rowNum = 1; rowNum <= amountOfRows; rowNum++)
            {
                // Iterate through each seat in the row
                for (int seatNum = 1; seatNum <= seatsPerRow; seatNum++)
                {
                    // Create a new Seat object with the row number and seat number, and add it to the list
                    seats.Add(new Seat(rowNum, seatNum));
                }
            }

            // Return the list of generated seats
            return seats;
        }


        public async Task<List<MovieTheater>> GetMovieTheaterListAsync()
        {
            return await movieTheaterBusinessController.GetMovieTheatersAsync();
        }

        public async Task<bool> AddAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasInserted = await movieTheaterBusinessController.AddAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

            return wasInserted;
        }

    }

}
