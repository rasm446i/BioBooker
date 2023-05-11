using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IMovieTheaterServiceApi
    {
        public Task<List<Auditorium>> GetAllAuditoriumsFromMovieTheaterIdAsync(int id);
        public Task<List<MovieTheater>> GetAllMovieTheatersAsync();
        public Task<bool> InsertMovieTheaterAsync(MovieTheater newTheater);
        public Task<bool> InsertSeats(List<Seat> seats, int auditoriumId);
        public Task<bool> InsertAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium);
        public Task<Auditorium> GetAuditoriumByIdAsync(int auditoriumId);


    }
}
