using BioBooker.Dml;
using BioBooker.Utl;
using BioBooker.WinApp.Svl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BioBooker.WinApp.UnitTests.Svl
{
    public class MoviesServiceTest
    {
        private MoviesService moviesService;
        private Base64EncodedImage utl;
        private IConfiguration configuration;
        public MoviesServiceTest() 
        {
            utl = new Base64EncodedImage();
            moviesService= new MoviesService(configuration);
        }

        [Fact]
        public async Task InsertMovieAsync_WithValidData_ReturnsTrue()
        {

            // Arrange
            var imagePath = @"insert image path";

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
                PremierDate = "2023-01-01",
                Poster = new Poster("Test Movie Poster", imageData)
            };

            var poster = new Poster
            {
                PosterTitle = "Test Movie Poster",
                ImageData = imageData
            };

            // Act
            bool inserted = await moviesService.InsertMovieAsync(movie, poster);

            // Assert
            Assert.True(inserted);
        }

        [Fact]
        public async Task InsertMovieAsync_WithInvalidMovieData_ReturnsFalse()
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
                MPARating = "",
                RuntimeMinutes = 120,
                PremierDate = "2023-01-01",
                Poster = new Poster("Test Movie Poster", imageData)
            };

            var poster = new Poster
            {
                PosterTitle = "Test Movie Poster",
                ImageData = imageData
            };

            // Act
            bool inserted = await moviesService.InsertMovieAsync(movie, poster);

            // Assert
            Assert.False(inserted);
        }

        [Fact]
        public async Task InsertMovieAsync_WithInvalidPosterData_ReturnsFalse()
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
                MPARating = "",
                RuntimeMinutes = 120,
                PremierDate = "2023-01-01",
                Poster = new Poster("Test Movie Poster", imageData)
            };

            Poster poster = null;

            // Act
            bool inserted = await moviesService.InsertMovieAsync(movie, poster);

            // Assert
            Assert.False(inserted);
        }


    }
}