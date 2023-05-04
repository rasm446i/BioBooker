using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.Dml;
using BioBooker.WebApi.Dal;
using Microsoft.Extensions.Configuration;

namespace BioBooker.WebApi.Svl
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IConfiguration configuration)
        {
            _moviesRepository = new MoviesRepository(configuration);
        }

        public async Task<bool> InsertMovieAsync(Movie movie)
        {
            return await _moviesRepository.AddMovieAsync(movie);
        }
    }
}