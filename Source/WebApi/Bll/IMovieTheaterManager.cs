using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Bll
{
    public interface IMovieTheaterManager
    {
        public Task<bool> InsertMovieTheaterAsync(MovieTheater newMovieTheater);
        public Task<Auditorium> GetAuditoriumByNameAndMovieTheaterIdAsync(string auditoriumName, int movieTheaterId);
        public Task<bool> InsertAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium);
        public Task<List<MovieTheater>> GetAllMovieTheatersAsync();
        public Task<List<Auditorium>> GetAllAuditoriumsFromMovieTheaterIdAsync(int id);
        public Task<bool> InsertSeatsAsync(List<Seat> seats, int auditoriumId);
    }
}
