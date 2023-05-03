using BioBooker.Dml;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IMoviesService
    {

        public Task<bool> InsertMovieAsync(Movie movie);
    }
}