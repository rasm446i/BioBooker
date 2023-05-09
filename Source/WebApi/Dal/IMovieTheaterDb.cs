using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Dal
{
    public interface IMovieTheaterDb
    {
        public Task<bool> InsertMovieTheaterAsync(MovieTheater newMovieTheater);
        public Task<List<MovieTheater>> GetAllMovieTheatersAsync();
        Task<List<Auditorium>> GetAllAuditoriumsFromMovieTheaterIdAsync(int id);

        public Task<bool> InsertSeats(List<Seat> seats,int movieTheaterId,int auditoriumId);
    }
}
