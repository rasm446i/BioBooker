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
    public class MovieTheaterBusiness
    {

        private readonly IMovieTheaterServiceApi _movieTheaterServiceApi;
        public MovieTheaterBusiness(IConfiguration configuration)
        {
            _movieTheaterServiceApi = new MovieTheaterServiceApi(configuration);
        }

        public async Task<bool> InsertMovieTheaterAsync(MovieTheater newMovieTheater)
        {
            bool wasInserted;

            wasInserted = await _movieTheaterServiceApi.InsertMovieTheaterAsync(newMovieTheater);

            return wasInserted;
        }
        public async Task<Auditorium> GetAuditoriumByNameAndMovieTheaterIdAsync(string auditoriumName, int movieTheaterId)
        {
            Auditorium foundAuditorium = await _movieTheaterServiceApi.GetAuditoriumByNameAndMovieTheaterIdAsync(auditoriumName, movieTheaterId);

            return foundAuditorium;
        }
        public async Task<bool> InsertAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasInserted;

            wasInserted = await _movieTheaterServiceApi.InsertAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

            return wasInserted;
        }

        public async Task<List<MovieTheater>> GetAllMovieTheatersAsync()
        {
           
           return await _movieTheaterServiceApi.GetAllMovieTheatersAsync();
           
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
