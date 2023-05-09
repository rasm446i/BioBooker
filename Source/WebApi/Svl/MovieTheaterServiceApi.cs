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
    public class MovieTheaterServiceApi : IMovieTheaterServiceApi
    {

        private readonly IMovieTheaterDb _movieTheaterDb;

        public MovieTheaterServiceApi(IConfiguration configuration) {
            _movieTheaterDb = new MovieTheaterDb(configuration);
        }

        public async Task<bool> InsertMovieTheaterAsync(MovieTheater newMovieTheater)
        {
            bool wasInserted;

            wasInserted = await _movieTheaterDb.InsertMovieTheaterAsync(newMovieTheater);

            return wasInserted;
        }

        public async Task<List<MovieTheater>> GetAllMovieTheatersAsync()
        {
          List<MovieTheater> movieTheaterList = await _movieTheaterDb.GetAllMovieTheatersAsync();

            return movieTheaterList;   
        }

        public async Task<List<Auditorium>> GetAllAuditoriumsFromMovieTheaterIdAsync(int id)
        {
            List<Auditorium> auditoriums = await _movieTheaterDb.GetAllAuditoriumsFromMovieTheaterIdAsync(id);

            return auditoriums;

        }

        public async Task<bool> InsertSeats(List<Seat> seats, int movieTheaterId, int auditoriumId)
        {
            return await _movieTheaterDb.InsertSeats(seats, movieTheaterId, auditoriumId);
        }
    }
}
