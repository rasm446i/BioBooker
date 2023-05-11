using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public interface IMovieTheaterService
    {
        public Task<bool> InsertMovieTheaterAsync(MovieTheater movieTheater);
        public Task<bool> InsertAuditoriumToMovieTheater(int movieTheaterId, Auditorium newAuditorium);
        public Task<MovieTheater> GetMovieTheaterAsync();
        public Task<List<MovieTheater>> GetMovieTheatersAsync();
        public Task<bool> UpdateMovieTheaterAsync();
        public Task<bool> DeleteMovieTheaterAsync();
    }
}
