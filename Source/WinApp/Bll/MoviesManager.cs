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

        // Creates a movie and inserts it along with the associated poster into the sql database.
        // Returns a boolean value indicating whether the movie insertion was successful.
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

        // Creates a new instance of the Movie class based on the provided movie object and returns it.
        public Movie CreateMovie(Movie movie)
        {
            Movie newMovie = new Movie(movie.Title, movie.Genre, movie.Actors, movie.Director, movie.Language, movie.ReleaseYear, movie.Subtitles, movie.SubtitlesLanguage, movie.MPARating, movie.RuntimeMinutes, movie.PremierDate, movie.Poster);

            return newMovie;
        }

        // Retrieves a movie by its title from the sql database.
        // Returns the movie if found, or null if an error occurs.
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

        // Retrieves all movies from the sql database.
        // Returns a list of movies if successful, or null if an error occurs.
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

        // Deletes a movie from the sql database by its ID.
        // Returns a boolean value indicating whether the movie deletion was successful.
        public async Task<bool> DeleteMovieByIdAsync(int id)
        {
            bool deleted;
            try
            {
                deleted = await _moviesService.DeleteMovie(id);
            }
            catch
            {
                deleted = false;
            }
            return deleted;
        }

    }
}