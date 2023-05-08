using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Dal
{
    public interface IMoviesRepository
    {
        public Task<bool> AddMovieAsync(Movie movie);
        public Task<List<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetMovieByTitleAsync(string title);
    }
}