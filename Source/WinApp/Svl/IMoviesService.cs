using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public interface IMoviesService
    {
        public Task<bool> InsertMovieAsync(Movie movieToAdd, Poster poster);
        public Task<Movie> GetMovieByTitleAsync(string title);
        public Task<bool> UpdateMovie(int id);
        public Task<bool> DeleteMovieByIdAsync(int id);
        public Task<List<Movie>> GetMovieByGenre(string genre);
        public Task<List<Movie>> GetAllMoviesAsync();
    }
}