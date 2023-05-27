using BioBooker.Dml;
using BioBooker.Utl;
using BioBooker.WebApi.Svl;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BioBooker.WinApp.UnitTests.Bll
{

    public class MoviesManagerTests
    {
        private MoviesManager _moviesManager;
        private Base64EncodedImage _utl;
        private IConfiguration _configuration;

        public MoviesManagerTests()
        {
            // Set up the configuration object with necessary configuration values

            _utl = new Base64EncodedImage();
            _moviesManager = new MoviesManager(_configuration);
        }

        [Fact]
        public async Task CreateMovie_WithValidData_ReturnsTrue()
        {
            // Arrange
            var imagePath = Directory.GetCurrentDirectory() + "\\TestPosters\\TestPoster1.jpg";

            var imageData = _utl.GenerateImageData(imagePath);

            var movie = new Movie
            {
                Title = "Test Movie 1",
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
            Movie createdMovie = _moviesManager.CreateMovie(movie);

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
        public async Task CreateMovie_EmptyMPARating_ThrowsArgumentException()
        {
            // Arrange
            var imagePath = Directory.GetCurrentDirectory() + "\\TestPosters\\TestPoster1.jpg";
            var imageData = _utl.GenerateImageData(imagePath);

            var movie = new Movie
            {
                Title = "Test Movie 1",
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

            // Act & Assert
            Exception ex = Assert.Throws<ArgumentException>(() => _moviesManager.CreateMovie(movie));
            Assert.Contains("MPARating", ex.Message);
        }


        [Fact]
        public async void CreateMovie_NullTitle_ThrowsArgumentException()
        {
            // Arrange
            var imagePath = Directory.GetCurrentDirectory() + "\\TestPosters\\TestPoster1.jpg";

            var imageData = _utl.GenerateImageData(imagePath);

            Movie movie = new Movie
            {
                // Set title to null
                Title = null,
                Genre = "Action",
                Actors = "John Doe, Jane Doe",
                Director = "John Smith",
                Language = "English",
                ReleaseYear = "2022",
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

            // Act & Assert
            Exception ex = Assert.Throws<ArgumentException>(() => _moviesManager.CreateMovie(movie));
            Assert.Contains("Title", ex.Message);
        }
    }
}



