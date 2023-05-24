using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace BioBooker.WinApp.UnitTests.Bll
{
    public class ShowingManagerTests
    {
        private ShowingManager _showingManager;
        private IConfiguration _configuration;

        public ShowingManagerTests()
        {
            _showingManager = new ShowingManager(_configuration);
        }

        [Fact]
        public async void CreateShowing_ValidData_ReturnsNewShowing()
        {
            // Arrange
            DateTime date = DateTime.Now;
            TimeSpan startTime = TimeSpan.FromHours(10);
            TimeSpan endTime = TimeSpan.FromHours(11);
            int auditoriumId = 1;
            int movieId = 1;

            Showing expectedShowing = new Showing(date, startTime, endTime, auditoriumId, movieId);

            // Act

            Showing createdShowing = await _showingManager.CreateShowing(expectedShowing);

            // Assert
            Assert.Equal(expectedShowing.Date, createdShowing.Date);
            Assert.Equal(expectedShowing.StartTime, createdShowing.StartTime);
            Assert.Equal(expectedShowing.EndTime, createdShowing.EndTime);
            Assert.Equal(expectedShowing.AuditoriumId, createdShowing.AuditoriumId);
            Assert.Equal(expectedShowing.MovieId, createdShowing.MovieId);
        }

        [Fact]
        public async void CreateShowing_InvalidShowing_ThrowsArgumentException()
        {
            // Arrange
            DateTime date = DateTime.Now;
            TimeSpan startTime = TimeSpan.FromHours(10);
            TimeSpan endTime = TimeSpan.FromHours(8);  // Invalid: end time is before start time
            int auditoriumId = 1;
            int movieId = 1;
            Showing showing = new Showing(date, startTime, endTime, auditoriumId, movieId);

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                // This code should throw an ArgumentException
                await _showingManager.CreateShowing(showing);
            });
        }

    }
}
