using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public class MoviesService : IMoviesService
    {
        private readonly IServiceConnection _moviesService;
        private readonly String _serviceBaseUrl = "url";
        
        public MoviesService() 
        {
            _moviesService = new ServiceConnection(_serviceBaseUrl);
        }

        public void AddMovie(Movie movieToAdd)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetMovieByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetMovies()
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(int id)
        {
            throw new NotImplementedException();
        }
    }
}
