using BioBooker.Dml;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IMoviesService
    {
        public Task<List<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetMovieByTitleAsync(string title);
        public Task<bool> InsertMovieAsync(Movie movie);
        public Task<bool> DeleteMovieByIdAsync(int id);
        public Task<bool> UpdateMovieByIdAsync(int id, Movie updatedMovie);
    }
}