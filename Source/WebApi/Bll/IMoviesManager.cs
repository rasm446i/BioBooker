using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Bll
{
    public interface IMoviesManager
    {
        public Task<Movie> GetMovieByTitleAsync(string title);

        public Task<bool> InsertMovieAsync(Movie movie);

        public Task<List<Movie>> GetAllMoviesAsync();

        public Task<bool> DeleteMovieByIdAsync(int id);

        public Task<bool> UpdateMovieByIdAsync(int id, Movie updatedMovie);

    }
}
