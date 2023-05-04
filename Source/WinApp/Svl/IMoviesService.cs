using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public interface IMoviesService
    {
        public Task<List<Movie>> GetMovies();
        public Task<bool> InsertMovieAsync(Movie movieToAdd);
        public Task<Movie> GetMovieByTitleAsync(string title);
        public Task<bool> UpdateMovie(int id);
        public Task<bool> DeleteMovie(int id);
        public Task<List<Movie>> GetMovieByGenre(string genre);
    }
}