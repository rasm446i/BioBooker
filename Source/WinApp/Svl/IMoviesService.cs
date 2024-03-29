using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public interface IMoviesService
    {
        public Task<bool> InsertMovieAsync(Movie movieToAdd, Poster poster);
        public Task<Movie> GetMovieByTitleAsync(string title);
        public Task<Movie> GetMovieByIdAsync(int id);
        public Task<bool> DeleteMovieByIdAsync(int id);
        public Task<List<Movie>> GetAllMoviesAsync();
        public Task<bool> UpdateMovieByIdAsync(int id, Movie updatedMovie);
    }
}