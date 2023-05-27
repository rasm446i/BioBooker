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
        public Task<Movie> GetMovieByIdAsync(int id);
        public Task<bool> DeleteMovieByIdAsync(int id);
        public Task<bool> UpdateMovieByIdAsync(int id, Movie updatedMovie);
        public Task<List<Showing>> GetShowingsByMovieIdAsync(int movieId);
    }
}