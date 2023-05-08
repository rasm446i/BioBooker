using BioBooker.Dml;
using System.Threading.Tasks;
using BioBooker.WinApp.Svl;
using Microsoft.Extensions.Configuration;

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
            Movie newMovie = new Movie(movie.Id, movie.Title, movie.Genre, movie.Actors, movie.Director, movie.Language, movie.ReleaseYear, movie.Subtitles, movie.SubtitlesLanguage, movie.MPARatingEnum, movie.RuntimeHours, movie.RuntimeMinutes, movie.PremierDate, movie.Poster);

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
    }
}