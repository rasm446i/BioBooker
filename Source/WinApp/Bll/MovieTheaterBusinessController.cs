using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.WinApp.Svl;

namespace BioBooker.WinApp.Bll
{
    public class MovieTheaterBusinessController
    {
        readonly IMovieTheaterService _movieTheaterService;
        public MovieTheaterBusinessController()
        {
            _movieTheaterService = new MovieTheaterService();
        }
        public async Task<bool> CreateMovieTheater(string movieTheaterName, List<Seat> seats)
        {
            bool wasInserted;
            try
            {
                // Create a new auditorium using the provided seat list
                Auditorium newAuditorium = await CreateAuditorium(seats);

                // Create a new movie theater with the provided name and the created auditorium
                MovieTheater newMovieTheater = new MovieTheater(movieTheaterName, newAuditorium);

                // Insert the new movie theater into the database asynchronously
                wasInserted = await InsertMovieTheaterAsync(newMovieTheater);
            }
            catch (Exception ex)
            {
                wasInserted = false;
            }

            // Return the result indicating whether the movie theater was successfully inserted or not
            return wasInserted;
        }

        public async Task<bool> InsertMovieTheaterAsync(MovieTheater movieTheater)
        {
            bool wasInserted = await _movieTheaterService.InsertMovieTheaterAsync(movieTheater);

            return wasInserted;
        }
        public async Task<Auditorium> CreateAuditorium(List<Seat> seats)
        {
            return await Task.FromResult(new Auditorium(seats));
        }

        public async Task<List<MovieTheater>> GetMovieTheatersAsync()
        {
            return await _movieTheaterService.GetMovieTheatersAsync();
        }

        public async Task<bool> AddAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasInserted = await _movieTheaterService.InsertAuditoriumToMovieTheater(movieTheaterId, newAuditorium);
            
            return wasInserted;
        }

    }
}