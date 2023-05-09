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
        public async Task CreateAndInsertMovieAsync_WithValidData_ReturnsTrue()
        {
            var imagePath = @"insert image path";

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
                PremierDate = "2023-01-02",
                Poster = new Poster("Test Movie Poster", imageData)
            };

            var poster = new Poster
            {
                PosterTitle = "Test Movie Poster",
                ImageData = imageData
            };

            // Act
            bool result = await moviesManager.CreateAndInsertMovieAsync(movie, poster);

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



