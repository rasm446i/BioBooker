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

namespace BioBooker.WinApp.IntegrationTests.Bll
{
    public class MoviesManagerIntegrationTest
    {

        private MoviesService moviesService;
        private Base64EncodedImage utl;
        private IConfiguration configuration;

        public MoviesManagerIntegrationTest()
        {
            utl = new Base64EncodedImage();
            moviesService = new MoviesService(configuration);
        }

        [Fact]
        public async Task CreateAndInsertMovieAsync_InsertsAndRetrievesMovie()
        {
            var imagePath = @"insert image path";

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
                PremierDate = "2023-01-01",
                Poster = new Poster("Test Movie Poster", imageData)
            };

            var poster = new Poster
            {
                PosterTitle = "Test Movie Poster",
                ImageData = imageData
            };

            // Act
            bool insertResult = await moviesService.InsertMovieAsync(movie, poster);
            Movie retrievedMovie = await moviesService.GetMovieByTitleAsync(movie.Title);

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
            Assert.Equal(movie.PremierDate, retrievedMovie.PremierDate);
            Assert.Equal(movie.Poster.PosterTitle, retrievedMovie.Poster.PosterTitle);
            Assert.Equal(movie.Poster.ImageData, retrievedMovie.Poster.ImageData);
        }
    }
}
