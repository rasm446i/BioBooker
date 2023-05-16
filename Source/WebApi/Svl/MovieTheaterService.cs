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

        public async Task<bool> InsertMovieTheaterAsync(MovieTheater newMovieTheater)
        {
            bool wasInserted;

            wasInserted = await _MovieTheaterRepository.InsertMovieTheaterAsync(newMovieTheater);

            return wasInserted;
        }

        public async Task<bool> InsertAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasInserted;

            wasInserted = await _MovieTheaterRepository.InsertAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

            return wasInserted;
        }
        public async Task<Auditorium> GetAuditoriumByNameAndMovieTheaterIdAsync(string auditoriumName, int movieTheaterId)
        {
            Auditorium foundAuditorium = await _MovieTheaterRepository.GetAuditoriumByNameAndMovieTheaterIdAsync(auditoriumName, movieTheaterId);

            return foundAuditorium;
        }
        public async Task<List<MovieTheater>> GetAllMovieTheatersAsync()
        {
          List<MovieTheater> movieTheaterList = await _MovieTheaterRepository.GetAllMovieTheatersAsync();

            return movieTheaterList;   
        }

        public async Task<List<Auditorium>> GetAllAuditoriumsFromMovieTheaterIdAsync(int id)
        {
            List<Auditorium> auditoriums = await _MovieTheaterRepository.GetAllAuditoriumsFromMovieTheaterIdAsync(id);

            return auditoriums;

        }

        public async Task<bool> InsertSeatsAsync(List<Seat> seats, int auditoriumId)
        {
            return await _MovieTheaterRepository.InsertSeatsAsync(seats, auditoriumId);
        }
    }
}
