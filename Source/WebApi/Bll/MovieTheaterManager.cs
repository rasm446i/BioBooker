using BioBooker.Dml;
using BioBooker.WebApi.Svl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Bll
{
    public class MovieTheaterManager : IMovieTheaterManager
    {

        private readonly IMovieTheaterService _movieTheaterServiceApi;
        public MovieTheaterManager(IConfiguration configuration)
        {
            _movieTheaterServiceApi = new MovieTheaterService(configuration);
        }

        /// <summary>
        /// Inserts a new movie theater in the database asynchronously.
        /// </summary>
        /// <param name="newMovieTheater">The new movie theater to be inserted.</param>
        /// <returns>
        /// A task that holds a boolean value indicating whether the movie theater was successfully inserted or not.
        /// </returns>
        public async Task<bool> InsertMovieTheaterAsync(MovieTheater newMovieTheater)
        {
            bool wasInserted;

            wasInserted = await _movieTheaterServiceApi.InsertMovieTheaterAsync(newMovieTheater);

            return wasInserted;
        }

        /// <summary>
        /// Inserts an auditorium into a movie theater in the database asynchronously.
        /// </summary>
        /// <param name="movieTheaterId">The ID of the movie theater to which the auditorium will be inserted.</param>
        /// <param name="newAuditorium">The auditorium to be inserted.</param>
        /// <returns>
        /// A task that holds a boolean value indicating whether the auditorium was successfully inserted into the movie theater or not.
        /// </returns>
        public async Task<bool> InsertAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasInserted;

            wasInserted = await _movieTheaterServiceApi.InsertAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

            return wasInserted;
        }

        /// <summary>
        /// Retrieves all movie theaters from the database asynchronously.
        /// </summary>
        /// <returns>
        /// A task that holds a list of movie theaters.
        /// </returns>
        public async Task<List<MovieTheater>> GetAllMovieTheatersAsync()
        {
           
           return await _movieTheaterServiceApi.GetAllMovieTheatersAsync();
           
        }

        public async Task<Auditorium> GetAuditoriumByNameAndMovieTheaterIdAsync(string auditoriumName, int movieTheaterId)
        {
            Auditorium foundAuditorium = await _movieTheaterServiceApi.GetAuditoriumByNameAndMovieTheaterIdAsync(auditoriumName, movieTheaterId);

            return foundAuditorium;
        }

        public async Task<List<Auditorium>> GetAllAuditoriumsFromMovieTheaterIdAsync(int id)
        {
            return await _movieTheaterServiceApi.GetAllAuditoriumsFromMovieTheaterIdAsync(id);
        }

        public async Task<bool> InsertSeatsAsync(List<Seat> seats, int auditoriumId)
        {
            return await _movieTheaterServiceApi.InsertSeatsAsync(seats, auditoriumId);
        }
    }
}
