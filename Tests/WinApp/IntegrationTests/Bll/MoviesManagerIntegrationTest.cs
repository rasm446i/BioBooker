using BioBooker.Dml;
using BioBooker.Utl;
using BioBooker.WinApp.Bll;
using BioBooker.WinApp.Svl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BioBooker.WinApp.IntegrationTests.Bll
{
    public class MoviesManagerIntegrationTest
    {
        private MoviesManager moviesManager;
        private Base64EncodedImage utl;
        private IConfiguration configuration;

        public MoviesManagerIntegrationTest()
        {
            utl = new Base64EncodedImage();
            moviesManager = new MoviesManager(configuration);
        }

        [Fact]
        public async Task CreateAndInsertMovieAsync_InsertsAndRetrievesMovie()
        {
            var imagePath = @"C:\Users\Visti\Desktop\Dyring.png";

            var imageData = utl.GenerateImageData(imagePath);

            // Arrange
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
            bool insertResult = await moviesManager.CreateAndInsertMovieAsync(movie, poster);
            Movie retrievedMovie = await moviesManager.GetMovieByTitleAsync(movie.Title);

            // Assert
            Assert.True(insertResult);
            Assert.NotNull(retrievedMovie);
            Assert.Equal(movie.Title, retrievedMovie.Title);
            Assert.Equal(movie.Genre, retrievedMovie.Genre);
            Assert.Equal(movie.Actors, retrievedMovie.Actors);
            Assert.Equal(movie.Director, retrievedMovie.Director);
            Assert.Equal(movie.Language, retrievedMovie.Language);
            Assert.Equal(movie.ReleaseYear, retrievedMovie.ReleaseYear);
            Assert.Equal(movie.Subtitles, retrievedMovie.Subtitles);
            Assert.Equal(movie.SubtitlesLanguage, retrievedMovie.SubtitlesLanguage);
            Assert.Equal(movie.MPARating, retrievedMovie.MPARating);
            Assert.Equal(movie.RuntimeMinutes, retrievedMovie.RuntimeMinutes);
            Assert.Equal(movie.Poster.PosterTitle, retrievedMovie.Poster.PosterTitle);
            Assert.Equal(movie.Poster.ImageData, retrievedMovie.Poster.ImageData);
        }

        [Fact]
        public async Task CreateAndInsertMovieAsync_WithValidData_ReturnsTrue()
        {
            var imagePath = @"INSERT IMAGE PATH";

            var imageData = utl.GenerateImageData(imagePath);

            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie19",
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
            bool result = await moviesManager.CreateAndInsertMovieAsync(movie, poster);
            bool expected;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CreateAndInsertMovieAsync_WithInvalidData_ReturnsFalse()
        {
            // Arrange
            var movie = new Movie(); // Invalid movie object

            var poster = new Poster(); // Invalid poster object

            // Act
            bool result = await moviesManager.CreateAndInsertMovieAsync(movie, poster);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task GetMovieByTitleAsync_WithExistingTitle_ReturnsMovie()
        {
            // Arrange
            string title = "Test Movie";

            // Act
            Movie movie = await moviesManager.GetMovieByTitleAsync(title);

            // Assert
            Assert.NotNull(movie);
            Assert.Equal(title, movie.Title);
        }

        [Fact]
        public async Task GetAllMoviesAsync_ReturnsListOfMovies()
        {
            // Act
            List<Movie> movies = await moviesManager.GetAllMoviesAsync();

            // Assert
            Assert.NotNull(movies);
            Assert.NotEmpty(movies);
        }
    }
}