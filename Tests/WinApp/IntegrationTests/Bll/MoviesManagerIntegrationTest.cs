using BioBooker.Dml;
using BioBooker.Utl;
using BioBooker.WinApp.Bll;
using BioBooker.WinApp.Svl;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private readonly string _connectionString = "server=localhost; Database=BioBooker; integrated security=true;";
        private readonly string _sqlScript = @"DELETE FROM movies WHERE Title = 'Test Movie1' OR Title = 'Test Movie2'";


        public MoviesManagerIntegrationTest()
        {
            utl = new Base64EncodedImage();
            moviesManager = new MoviesManager(configuration);
        }

        [Fact]
        public async Task CreateAndInsertMovieAsync_InsertsAndRetrievesMovie()
        {
            ResetDatabase();
            var imagePath = Directory.GetCurrentDirectory() + "\\TestPosters\\TestPoster1.jpg";


            var imageData = utl.GenerateImageData(imagePath);


            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie1",
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
            Assert.Equal(movie.Subtitles, retrievedMovie.Subtitles);
            Assert.Equal(movie.SubtitlesLanguage, retrievedMovie.SubtitlesLanguage);
            Assert.Equal(movie.MPARating, retrievedMovie.MPARating);
            Assert.Equal(movie.RuntimeMinutes, retrievedMovie.RuntimeMinutes);
            Assert.Equal(movie.Poster.PosterTitle, retrievedMovie.Poster.PosterTitle);
            Assert.Equal(movie.Poster.ImageData, retrievedMovie.Poster.ImageData);

            ResetDatabase();
        }

        [Fact]
        public async Task CreateAndInsertMovieAsync_WithValidData_ReturnsTrue()
        {
            ResetDatabase();
            var imagePath = Directory.GetCurrentDirectory() + "\\TestPosters\\TestPoster1.jpg";

            var imageData = utl.GenerateImageData(imagePath);


            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie2",
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
            ResetDatabase();
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
            string title = "wowIE";

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

        private void ResetDatabase()
        {
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    connection.Execute(_sqlScript);
                    connection.Close();
                }
            }

        }
    }
}