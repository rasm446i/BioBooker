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
        public async Task<bool> CreateMovieTheaterAndInsertAsync(string movieTheaterName, List<Seat> seats, string auditoriumName)
        {
            bool wasInserted;
            try
            {
                // Create a new auditorium using the provided seat list and auditorium name
                Auditorium newAuditorium = CreateAuditorium(seats, auditoriumName);

                // Create a new movie theater with the provided name and the created auditorium
                MovieTheater newMovieTheater = CreateMovieTheater(movieTheaterName, newAuditorium);

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
        public Auditorium CreateAuditorium(List<Seat> seats, string auditoriumName)
        {
            return new Auditorium(seats, auditoriumName);
        }

        public MovieTheater CreateMovieTheater(string movieTheaterName, Auditorium newAuditorium)
        {
            return new MovieTheater(movieTheaterName, newAuditorium);
        }

        public async Task<List<MovieTheater>> GetMovieTheatersAsync()
        {
            return await _movieTheaterService.GetMovieTheatersAsync();
        }

        public async Task<bool> AddAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasInserted = await _movieTheaterService.InsertAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);
            
            return wasInserted;
        }

    }
}