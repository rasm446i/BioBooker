using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;

namespace BioBooker.WinApp.Uil.Controllers
{
    public class MovieController
    {
        private readonly IMoviesManager _moviesManager;

        public MovieController(IConfiguration configuration)
        {
            _moviesManager = new MoviesManager(configuration);
        }

        public async Task<bool> CreateAndInsertMovieAsync(Movie movie, Poster poster)
        {
            List<string> validationErrors = ValidateMovie(movie, poster);

            if (validationErrors.Count > 0)
            {
                throw new InvalidOperationException($"Movie validation failed: {string.Join("; ", validationErrors)}");
            }

            return await _moviesManager.CreateAndInsertMovieAsync(movie, poster);
        }

        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            return await _moviesManager.GetMovieByTitleAsync(title);
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _moviesManager.GetAllMoviesAsync();
        }

        public async Task<bool> DeleteMovieByIdAsync(int id)
        {
            return await _moviesManager.DeleteMovieByIdAsync(id);
        }

        public async Task<bool> UpdateMovieByIdAsync(int id, Movie updatedMovie)
        {
            List<string> validationErrors = ValidateMovie(updatedMovie, updatedMovie.Poster);

            if (validationErrors.Count > 0)
            {
                throw new InvalidOperationException($"Movie validation failed: {string.Join("; ", validationErrors)}");
            }

            return await _moviesManager.UpdateMovieByIdAsync(id, updatedMovie);
        }

        private List<string> ValidateMovie(Movie movie, Poster poster)
        {
            List<string> errors = new List<string>();

            // Validate title
            if (string.IsNullOrEmpty(movie.Title))
            {
                errors.Add("Please enter a title.");
            }

            // Validate genre
            if (string.IsNullOrEmpty(movie.Genre))
            {
                errors.Add("Please select a genre.");
            }

            // Validate actors
            if (string.IsNullOrEmpty(movie.Actors))
            {
                errors.Add("Please enter actors.");
            }

            // Validate director
            if (string.IsNullOrEmpty(movie.Director))
            {
                errors.Add("Please enter a director.");
            }

            // Validate language
            if (string.IsNullOrEmpty(movie.Language))
            {
                errors.Add("Please select a language.");
            }

            // Validate release year
            if (string.IsNullOrEmpty(movie.ReleaseYear))
            {
                errors.Add("Please select a Release Date.");
            }

            // Validate Premier date
            if (string.IsNullOrEmpty(movie.PremierDate))
            {
                errors.Add("Please select a Premier date.");
            }

            // Validate subtitles
            if (movie.Subtitles == null)
            {
                errors.Add("Please select if the movie has subtitles.");
            }

            // Validate runtime
            if (movie.RuntimeMinutes <= 0)
            {
                errors.Add("Please enter a valid runtime.");
            }

            // Validate poster
            if (poster == null || poster.ImageData == null || poster.ImageData.Length == 0)
            {
                errors.Add("Please select a picture.");
            }

            return errors;
        }
    }
}
