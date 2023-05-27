using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApp.Svl
{
    public interface IMovieServiceApi
    {
        public Task<List<Movie>> GetMovies();
        public Task<List<Showing>> GetShowingsByMovieIdAsync(int movieId);
    }
}
