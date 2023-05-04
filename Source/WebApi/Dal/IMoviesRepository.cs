using BioBooker.Dml;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Dal
{
    public interface IMoviesRepository
    {
        public Task<bool> AddMovieAsync(Movie movie);

        public Task<Movie> GetMovieByTitleAsync(string title);
    }
}