using BioBooker.Dml;
using BioBooker.WebApi.Dal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BioBooker.WebApi.Svl
{
    public class MovieTheaterService : IMovieTheaterService
    {

        private readonly IMovieTheaterRepository _MovieTheaterRepository;

        public MovieTheaterService(IConfiguration configuration) 
        {
            _MovieTheaterRepository = new MovieTheaterRepository(configuration);
        }

        /// <summary>
        /// Inserts a new movie theater into the database asynchronously.
        /// </summary>
        /// <param name="newMovieTheater">The new movie theater to be inserted.</param>
        /// <returns>
        /// A task that holds a boolean value indicating whether the movie theater was successfully inserted or not.
        /// </returns>
        public async Task<bool> InsertMovieTheaterAsync(MovieTheater newMovieTheater)
        {
            bool wasInserted;

            wasInserted = await _MovieTheaterRepository.InsertMovieTheaterAsync(newMovieTheater);

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

            wasInserted = await _MovieTheaterRepository.InsertAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

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
            List<MovieTheater> movieTheaterList = await _MovieTheaterRepository.GetAllMovieTheatersAsync();

            return movieTheaterList;
        }

        /// <summary>
        /// Retrieves an auditorium by its name and movie theater ID asynchronously.
        /// </summary>
        /// <param name="auditoriumName">The name of the auditorium.</param>
        /// <param name="movieTheaterId">The ID of the movie theater.</param>
        /// <returns>Returns the found auditorium or null if not found.</returns>
        public async Task<Auditorium> GetAuditoriumByNameAndMovieTheaterIdAsync(string auditoriumName, int movieTheaterId)
        {
            Auditorium foundAuditorium = await _MovieTheaterRepository.GetAuditoriumByNameAndMovieTheaterIdAsync(auditoriumName, movieTheaterId);

            return foundAuditorium;
        }

        /// <summary>
        /// Retrieves all auditoriums associated with a movie theater ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the movie theater.</param>
        /// <returns>Returns a list of auditoriums or an empty list if none found.</returns>
        public async Task<List<Auditorium>> GetAllAuditoriumsFromMovieTheaterIdAsync(int id)
        {
            List<Auditorium> auditoriums = await _MovieTheaterRepository.GetAllAuditoriumsFromMovieTheaterIdAsync(id);

            return auditoriums;

        }

        /// <summary>
        /// Inserts a list of seats into an auditorium asynchronously.
        /// </summary>
        /// <param name="seats">The list of seats to insert.</param>
        /// <param name="auditoriumId">The ID of the auditorium.</param>
        /// <returns>Returns true if the seats were inserted successfully, false otherwise.</returns>
        public async Task<bool> InsertSeatsAsync(List<Seat> seats, int auditoriumId)
        {
            return await _MovieTheaterRepository.InsertSeatsAsync(seats, auditoriumId);
        }
    }
}
