using BioBooker.Dml;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IMoviesService
    {
        Task<Movie> GetMovieByTitleAsync(string title);
        public Task<bool> InsertMovieAsync(Movie movie);
    }
}