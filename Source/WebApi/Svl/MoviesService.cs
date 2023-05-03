using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.Dml;
using BioBooker.WebApi.Dal;

namespace BioBooker.WebApi.Svl
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService()
        {
            _moviesRepository = new MoviesRepository();
        }

        public async Task<bool> InsertMovieAsync(Movie movie)
        {
            return await _moviesRepository.AddMovieAsync(movie);
        }
    }
}
