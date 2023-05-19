using BioBooker.Dml;
using BioBooker.WinApp.Svl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Bll
{
    public class ShowingManager : IShowingManager
    {

        private readonly IShowingService _showingService;
        private readonly IMoviesManager _moviesManager;


        /// <summary>
        /// Constructor for the ShowingManager class.
        /// </summary>
        /// <param name="configuration">The configuration object used for dependency injection.</param>
        public ShowingManager(IConfiguration configuration)
        {
            _showingService = new ShowingService(configuration);
            _moviesManager = new MoviesManager(configuration);
        }


        /// <summary>
        /// Creates and inserts a showing into the database.
        /// </summary>
        /// <param name="showing">The showing to create and insert.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a value indicating whether the showing was inserted successfully.</returns>
        public async Task<bool> CreateAndInsertShowingAsync(Showing showing)
        {
            bool inserted;
            try
            {
                Showing createdShowing = await CreateShowing(showing);

                // Check if a showing with the same start time and end time already exists
                bool showingExists = await ShowingExists(createdShowing.AuditoriumId, createdShowing.StartTime, createdShowing.EndTime, createdShowing.Date);
                if (showingExists)
                {
                    Console.WriteLine("A showing with the same start time and end time already exists.");
                    inserted = false;
                }
                else
                {
                    inserted = await _showingService.InsertShowingAsync(createdShowing);
                }
            }
            catch
            {
                inserted = false;
            }

            return inserted;
        }

        public async Task<bool> ShowingExists(int auditoriumId, TimeSpan startTime, TimeSpan endTime, DateTime date)
        {
            List<Showing> showings = await _showingService.GetShowingsByAuditoriumIdAndDateAsync(auditoriumId, date);

            foreach (Showing showing in showings)
            {
                if (showing.StartTime == startTime && showing.EndTime == endTime)
                {
                    return true;
                }
            }

            return false;
        }




        /// <summary>
        /// Creates a showing object based on the provided showing information and performs validation.
        /// </summary>
        /// <param name="showing">The showing to create.</param>
        /// <returns>The created showing object.</returns>
        /// <exception cref="ArgumentException">Thrown when the date is before today, the movie ID is invalid, or the end time is before the start time.</exception>
        public async Task<Showing> CreateShowing(Showing showing)
        {
            // Validate date
            if (showing.Date < DateTime.Today)
            {
                throw new ArgumentException("Cannot choose a date before today.");
            }


            // Validate movie ID
            // Assume you have a method to check if the movie exists based on its ID
  //      bool movieExists = await MovieExists(showing.MovieId);
  //         throw new ArgumentException("Invalid movie ID. The specified movie does not exist.");
  //    }


          /*  // Validate movie ID

            bool movieExists = await MovieExists(showing.MovieId);
            if (!movieExists)
            {
                throw new ArgumentException("Invalid movie ID. The specified movie does not exist.");
            }
*/

            // Validate time range
            if (showing.EndTime < showing.StartTime)
            {
                throw new ArgumentException("End time cannot be before start time.");
            }

            Showing newShowing = new Showing(showing.Date, showing.StartTime, showing.EndTime, showing.AuditoriumId, showing.MovieId);

            return newShowing;
        }



        /// <summary>
        /// Checks if a movie exists based on its ID.
        /// </summary>
        /// <param name="movieId">The ID of the movie to check.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a value indicating whether the movie exists.</returns>
        private async Task<bool> MovieExists(string title, string director, string releaseYear)
        {
            List<Movie> movies = await _moviesManager.GetAllMoviesAsync();

            foreach (Movie movie in movies)
            {
                if (movie.Title == title && movie.Director == director && movie.ReleaseYear == releaseYear)
                {
                    return true;
                }
            }

            return false;
        }



        /// <summary>
        /// Inserts a reservation into the database based on the showing ID.
        /// </summary>
        /// <param name="reservation">The reservation to insert.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a value indicating whether the reservation was inserted successfully.</returns>
        public async Task<bool> InsertReservationByShowingIdAsync(SeatReservation reservation)
        {
            bool reserved;
            try
            {
                reserved = await _showingService.InsertReservationAsync(reservation);
            }
            catch
            {
                reserved = false;
            }
            return reserved;
        }

        /// <summary>
        /// Retrieves a list of showings from the SQL database based on the auditorium ID and date.
        /// </summary>
        /// <param name="auditoriumId">The ID of the auditorium.</param>
        /// <param name="date">The date of the showings.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a list of showings if successful, or null if an error occurs.</returns>
        public async Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date)
        {
            List<Showing> showings;
            try
            {
                showings = await _showingService.GetShowingsByAuditoriumIdAndDateAsync(auditoriumId, date);
            }
            catch
            {
                showings = null;
            }
            return showings;
        }

    }
}
