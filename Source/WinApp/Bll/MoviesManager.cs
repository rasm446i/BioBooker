using BioBooker.Dml;
using System.Threading.Tasks;
using BioBooker.WinApp.Svl;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;

namespace BioBooker.WinApp.Bll
{
    public class MoviesManager : IMoviesManager
    {
        private readonly IMoviesService _moviesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesManager"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public MoviesManager(IConfiguration configuration)
        {
            _moviesService = new MoviesService(configuration);
        }

        /// <summary>
        /// Creates a movie and inserts it along with the associated poster into the SQL database.
        /// </summary>
        /// <param name="movie">The movie to create and insert.</param>
        /// <param name="poster">The associated poster of the movie.</param>
        /// <returns>A boolean value indicating whether the movie insertion was successful.</returns>
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

        /// <summary>
        /// Creates a new instance of the Movie class based on the provided movie object and returns it.
        /// </summary>
        /// <param name="movie">The movie object to create a new instance from.</param>
        /// <returns>The new instance of the Movie class.</returns>
        public Movie CreateMovie(Movie movie)
        {
            // Validate the movie properties
            ValidateMovieProperties(movie);

            Movie newMovie = new Movie(movie.Title, movie.Genre, movie.Actors, movie.Director, movie.Language, movie.ReleaseYear, movie.Subtitles, movie.SubtitlesLanguage, movie.MPARating, movie.RuntimeMinutes, movie.Poster);

            return newMovie;
        }

        /// <summary>
        /// Validates the properties of the Movie object.
        /// </summary>
        /// <param name="movie">The movie object to validate.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when one or more movie properties are invalid.
        /// </exception>
        private void ValidateMovieProperties(Movie movie)
        {
            // Check if the title is null or empty
            if (string.IsNullOrEmpty(movie.Title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(movie.Title));
            }

            // Check if the genre is null or empty
            if (string.IsNullOrEmpty(movie.Genre))
            {
                throw new ArgumentException("Genre cannot be null or empty.", nameof(movie.Genre));
            }

            // Check if the actors is null or empty
            if (string.IsNullOrEmpty(movie.Actors))
            {
                throw new ArgumentException("Actors cannot be null or empty.", nameof(movie.Actors));
            }

            // Check if the director is null or empty
            if (string.IsNullOrEmpty(movie.Director))
            {
                throw new ArgumentException("Director cannot be null or empty.", nameof(movie.Director));
            }

            // Check if the language is null or empty
            if (string.IsNullOrEmpty(movie.Language))
            {
                throw new ArgumentException("Language cannot be null or empty.", nameof(movie.Language));
            }

            // Check if the release year is null or empty
            if (string.IsNullOrEmpty(movie.ReleaseYear))
            {
                throw new ArgumentException("Release year cannot be null or empty.", nameof(movie.ReleaseYear));
            }

            // Check if the subtitles language is null or empty
            if (string.IsNullOrEmpty(movie.SubtitlesLanguage))
            {
                throw new ArgumentException("Subtitles language cannot be null or empty.", nameof(movie.SubtitlesLanguage));
            }

            // Check if the MPA rating is null or empty
            if (string.IsNullOrEmpty(movie.MPARating))
            {
                throw new ArgumentException("MPA rating cannot be null or empty.", nameof(movie.MPARating));
            }

            // Check if the runtime minutes is negative
            if (movie.RuntimeMinutes < 0)
            {
                throw new ArgumentException("Runtime minutes cannot be negative.", nameof(movie.RuntimeMinutes));
            }

            // Check if the poster is null
            if (movie.Poster == null)
            {
                throw new ArgumentNullException(nameof(movie.Poster), "Poster cannot be null.");
            }

            // You can add additional validations as per your requirements
        }

        /// <summary>
        /// Retrieves a movie by its title from the SQL database.
        /// </summary>
        /// <param name="title">The title of the movie to retrieve.</param>
        /// <returns>The movie if found, or null if an error occurs.</returns>
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

        /// <summary>
        /// Retrieves a movie by its ID from the SQL database.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns>The movie if found, or null if an error occurs.</returns>
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            Movie movie;
            try
            {
                movie = await _moviesService.GetMovieByIdAsync(id);
            }
            catch
            {
                movie = null;
            }
            return movie;
        }

        /// <summary>
        /// Retrieves all movies from the SQL database.
        /// </summary>
        /// <returns>A list of movies if successful, or null if an error occurs.</returns>
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

        /// <summary>
        /// Deletes a movie from the SQL database by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        /// <returns>A boolean value indicating whether the movie deletion was successful.</returns>
        public async Task<bool> DeleteMovieByIdAsync(int id)
        {
            bool deleted;
            try
            {
                deleted = await _moviesService.DeleteMovieByIdAsync(id);
            }
            catch
            {
                deleted = false;
            }
            return deleted;
        }

        /// <summary>
        /// Updates a movie in the SQL database by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="updatedMovie">The updated movie object.</param>
        /// <returns>A boolean value indicating whether the movie update was successful.</returns>
        public async Task<bool> UpdateMovieByIdAsync(int id, Movie updatedMovie)
        {
            bool updated;
            try
            {
                updated = await _moviesService.UpdateMovieByIdAsync(id, updatedMovie);
            }
            catch
            {
                updated = false;
            }
            return updated;
        }
    }
}
