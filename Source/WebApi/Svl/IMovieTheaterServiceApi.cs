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
        Task<List<Auditorium>> GetAllAditoriumsFromMovieIdAsync(int id);
        public Task<List<MovieTheater>> GetAllMovieTheatersAsync();

        public Task<bool> InsertMovieTheaterAsync(MovieTheater newTheater);

    }
}
