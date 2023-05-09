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

        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            return await _moviesRepository.GetMovieByTitleAsync(title);
        }

        public async Task<bool> InsertMovieAsync(Movie movie)
        {
            return await _moviesRepository.AddMovieAsync(movie);
        }
        
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _moviesRepository.GetAllMoviesAsync();
        }

        public async Task<bool> DeleteMovieByIdAsync(int id)
        {
            return await _moviesRepository.DeleteMovieByIdAsync(id);
        }

    }
}