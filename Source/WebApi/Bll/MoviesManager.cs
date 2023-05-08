using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.Dml;
using BioBooker.WebApi.Svl;
using Microsoft.Extensions.Configuration;

namespace BioBooker.WebApi.Bll
{
    public class MoviesManager
    {
        private readonly IMoviesService _moviesService;

        public MoviesManager(IConfiguration inConfiguration)
        {
            _moviesService = new MoviesService(inConfiguration);
        }

        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            return await _moviesService.GetMovieByTitleAsync(title);
        }

        public async Task<bool> InsertMovieAsync(Movie movie)
        {
            return await _moviesService.InsertMovieAsync(movie);
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _moviesService.GetAllMoviesAsync();
        }
    }
}
