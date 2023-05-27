using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.WinApp.Svl;

namespace BioBooker.WinApp.Bll
{
    public class MovieTheaterManager : IMovieTheaterManager
    {
        readonly IMovieTheaterService _movieTheaterService;
        public MovieTheaterManager()
        {
            _movieTheaterService = new MovieTheaterService();
        }

        /// <summary>
        /// Creates an auditorium with a list of seats and the name of the auditorium.
        /// Afterwards it creates a new movie theater with the specified name and the newly created auditorium.
        /// </summary>
        /// <param name="movieTheaterName">The name of the movie theater to be created.</param>
        /// <param name="seats">The list of seats for the auditorium.</param>
        /// <param name="auditoriumName">The name of the auditorium within the movie theater.</param>
        /// <returns>A task that holds a boolean indicating whether the movie theater was successfully created and inserted.</returns>
        public async Task<bool> CreateMovieTheaterAndInsertAsync(string movieTheaterName, List<Seat> seats, string auditoriumName)
        {
            bool wasInserted;
            try
            {
                Auditorium newAuditorium = CreateAuditorium(seats, auditoriumName);
                MovieTheater newMovieTheater = CreateMovieTheater(movieTheaterName, newAuditorium);

                // Inserts the new movie theater into the database asynchronously
                wasInserted = await InsertMovieTheaterAsync(newMovieTheater);
            }
            catch (Exception ex)
            {
                wasInserted = false;
            }

            // Return the result indicating whether the movie theater was successfully inserted or not
            return wasInserted;
        }

        /// <summary>
        /// Inserts a movie theater into the database asynchronously.
        /// </summary>
        /// <param name="movieTheater">The movie theater to be inserted.</param>
        /// <returns>A task that holds a boolean indicating whether the movie theater was successfully inserted or not.</returns>
        public async Task<bool> InsertMovieTheaterAsync(MovieTheater movieTheater)
        {
            bool wasInserted = await _movieTheaterService.InsertMovieTheaterAsync(movieTheater);

            return wasInserted;
        }

        /// <summary>
        /// Creates a new auditorium with the specified seats and auditorium name.
        /// </summary>
        /// <param name="seats">The list of seats for the auditorium.</param>
        /// <param name="auditoriumName">The name of the auditorium.</param>
        /// <returns>The created auditorium.</returns>
        public Auditorium CreateAuditorium(List<Seat> seats, string auditoriumName)
        {
            return new Auditorium(seats, auditoriumName);
        }

        /// <summary>
        /// Creates a new movie theater with the specified name and auditorium.
        /// </summary>
        /// <param name="movieTheaterName">The name of the movie theater.</param>
        /// <param name="newAuditorium">The auditorium to be added movie theater that is being created.</param>
        /// <returns>The created movie theater.</returns>
        public MovieTheater CreateMovieTheater(string movieTheaterName, Auditorium newAuditorium)
        {
            return new MovieTheater(movieTheaterName, newAuditorium);
        }

        /// <summary>
        /// Retrieves a list of movie theaters from the database asynchronously.
        /// </summary>
        /// <returns>A task that holds a list of movie theaters.</returns>
        public async Task<List<MovieTheater>> GetMovieTheatersAsync()
        {
            return await _movieTheaterService.GetMovieTheatersAsync();
        }

        /// <summary>
        /// Adds an auditorium to a movie theater in the database asynchronously.
        /// </summary>
        /// <param name="movieTheaterId">The ID of the movie theater to which the auditorium will be added.</param>
        /// <param name="newAuditorium">The auditorium to be added to the movie theater.</param>
        /// <returns>A task that holds a boolean indicating whether the auditorium was successfully added to the movie theater or not.</returns>
        public async Task<bool> AddAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasInserted = await _movieTheaterService.InsertAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);
            
            return wasInserted;
        }

        /// <summary>
        /// Generates a list of seats based on the specified number of rows and seats per row.
        /// </summary>
        /// <param name="amountOfRows">The number of rows in the auditorium.</param>
        /// <param name="seatsPerRow">The number of seats per row in the auditorium.</param>
        /// <returns>A list of seats.</returns>
        public List<Seat> GetGeneratedSeats(int amountOfRows, int seatsPerRow)
        {
            List<Seat> seats = new List<Seat>();

            // Iterate through each row
            for (int rowNum = 1; rowNum <= amountOfRows; rowNum++)
            {
                // Iterate through each seat in the row
                for (int seatNum = 1; seatNum <= seatsPerRow; seatNum++)
                {
                    // Create a new Seat with the row number and seat number, and add it to the list
                    seats.Add(new Seat(rowNum, seatNum));
                }
            }

            return seats;
        }

    }
}