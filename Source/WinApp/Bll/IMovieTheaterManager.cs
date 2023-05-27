using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Bll
{
    public interface IMovieTheaterManager
    {
        public Task<bool> CreateMovieTheaterAndInsertAsync(string movieTheaterName, List<Seat> seats, string auditoriumName);
        public Task<bool> InsertMovieTheaterAsync(MovieTheater movieTheater);
        public Auditorium CreateAuditorium(List<Seat> seats, string auditoriumName);
        public MovieTheater CreateMovieTheater(string movieTheaterName, Auditorium newAuditorium);
        public Task<List<MovieTheater>> GetMovieTheatersAsync();
        public Task<bool> AddAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium);
        public List<Seat> GetGeneratedSeats(int amountOfRows, int seatsPerRow);





    }
}
