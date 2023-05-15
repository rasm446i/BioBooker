using BioBooker.Dml;
using BioBooker.Utl;
using BioBooker.WebApi.Svl;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BioBooker.WinApp.UnitTests.Bll
{

    public class MoviesManagerTests
    {
        private MoviesManager moviesManager;
        private Base64EncodedImage utl;
        private IConfiguration configuration;

        public MoviesManagerTests()
        {
            // Set up the configuration object with necessary configuration values

            utl = new Base64EncodedImage();
            moviesManager = new MoviesManager(configuration);
        }

        [Fact]
        public async Task CreateMovie_WithValidData_ReturnsTrue()
        {
            // Arrange
            var imagePath = @"INSERT IMAGE PATH";

            var imageData = utl.GenerateImageData(imagePath);

            var movie = new Movie
            {
                Title = "Test Movie70",
                Genre = "Action",
                Actors = "Actor 1, Actor 2",
                Director = "Director Name",
                Language = "English",
                ReleaseYear = "2023-01-01",
                Subtitles = 1,
                SubtitlesLanguage = "English",
                MPARating = "PG-13",
                RuntimeMinutes = 120,
                Poster = new Poster("Test Movie Poster", imageData)
            };

            var poster = new Poster
            {
                PosterTitle = "Test Movie Poster",
                ImageData = imageData
            };

            // Act
            Movie createdMovie = moviesManager.CreateMovie(movie);

            // Assert
            Assert.NotNull(createdMovie);
            Assert.NotSame(movie, createdMovie);
            Assert.Equal(movie.Title, createdMovie.Title);
            Assert.Equal(movie.Genre, createdMovie.Genre);
            Assert.Equal(movie.Actors, createdMovie.Actors);
            Assert.Equal(movie.Director, createdMovie.Director);
            Assert.Equal(movie.Language, createdMovie.Language);
            Assert.Equal(movie.ReleaseYear, createdMovie.ReleaseYear);
            Assert.Equal(movie.Subtitles, createdMovie.Subtitles);
            Assert.Equal(movie.SubtitlesLanguage, createdMovie.SubtitlesLanguage);
            Assert.Equal(movie.MPARating, createdMovie.MPARating);
            Assert.Equal(movie.RuntimeMinutes, createdMovie.RuntimeMinutes);
            Assert.Equal(movie.Poster.PosterTitle, createdMovie.Poster.PosterTitle);
            Assert.Equal(movie.Poster.ImageData, createdMovie.Poster.ImageData);
        }

        [Fact]
        public async Task CreateMovie_WithInvalidMovieData_ReturnsFalse()
        {
            //NEEDS BUSINESS LOGIC
            // Arrange
            var imagePath = @"INSERT IMAGE PATH";

            var imageData = utl.GenerateImageData(imagePath);

            var movie = new Movie
            {
                Title = "Test Movie70",
                Genre = "Action",
                Actors = "Actor 1, Actor 2",
                Director = "Director Name",
                Language = "English",
                ReleaseYear = "2023-01-01",
                Subtitles = 1,
                SubtitlesLanguage = "English",
                MPARating = "",
                RuntimeMinutes = 120,
                Poster = new Poster("Test Movie Poster", imageData)
            };

            var poster = new Poster
            {
                PosterTitle = "Test Movie Poster",
                ImageData = imageData
            };

            // Act
            Movie createdMovie = moviesManager.CreateMovie(movie);

            // Assert
            Assert.Null(createdMovie);
        }
    }
}



