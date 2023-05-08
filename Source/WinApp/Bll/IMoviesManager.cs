using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Bll
{
    public interface IMoviesManager
    {
        public Movie CreateMovie(Movie movie);

        public Task<bool> CreateAndInsertMovieAsync(Movie movie, Poster poster);

        public Task<Movie> GetMovieByTitleAsync(string title);

        public Task<List<Movie>> GetAllMoviesAsync();
    }
}