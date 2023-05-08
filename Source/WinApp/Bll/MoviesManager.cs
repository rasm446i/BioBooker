using BioBooker.Dml;
using System.Threading.Tasks;
using BioBooker.WinApp.Svl;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BioBooker.WinApp.Bll
{
    public class MoviesManager : IMoviesManager
    {
        private readonly IMoviesService _moviesService;

        public MoviesManager(IConfiguration configuration)
        {
            _moviesService = new MoviesService(configuration);
        }


        public async Task<bool> CreateAndInsertMovieAsync(Movie movie, Poster poster)
        {
            bool inserted;
            try
            {
                Movie createdMovie = CreateMovie(movie);

                inserted = await _moviesService.InsertMovieAsync(createdMovie, poster);

            }
            catch
            {
                inserted = false;
            }

            return inserted;
        }

        public Movie CreateMovie(Movie movie)
        {
            Movie newMovie = new Movie(movie.Title, movie.Genre, movie.Actors, movie.Director, movie.Language, movie.ReleaseYear, movie.Subtitles, movie.SubtitlesLanguage, movie.MPARating, movie.RuntimeMinutes, movie.PremierDate, movie.Poster);

            return newMovie;
        }

        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            Movie movie;
            try
            {
                movie = await _moviesService.GetMovieByTitleAsync(title);
            }
            catch
            {
                movie = null;
            }
            return movie;
        
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            List<Movie> movies;
            try
            {
                movies = await _moviesService.GetAllMoviesAsync();
            }
            catch
            {
                movies = null;
            }
            return movies;
        }

    }
}