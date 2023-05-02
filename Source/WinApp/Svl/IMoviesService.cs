using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public interface IMoviesService
    {
        public Task<List<Movie>> GetMovies();
        public Task<bool> InsertMovieTheaterAsync(Movie movieToAdd);
        public Task<Movie> GetMovieById(int id);
        public Task<bool> UpdateMovie(int id);
        public Task<bool> DeleteMovie(int id);
        public Task<List<Movie>> GetMovieByGenre(string genre);
    }
}