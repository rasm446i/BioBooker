using BioBooker.Dml;
using BioBooker.WebApi.Bll;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BioBooker.WinApp.Bll.Tests
{
    public class ShowingManagerIntegrationTests
    {
        private IConfiguration configuration;
        private IShowingManager showingManager;

        public ShowingManagerIntegrationTests()
        {
            showingManager = new ShowingManager(configuration);
            
        }

        [Fact]
        public async Task CreateAndInsertShowingAsync_ValidShowing_ReturnsTrue()
        {
            // Arrange
            Showing showing = new Showing(DateTime.Now, TimeSpan.FromHours(10), TimeSpan.FromHours(11), 1, 1);

            // Act
            bool result = await showingManager.CreateAndInsertShowingAsync(showing);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CreateAndInsertShowingAsync_InvalidShowing_ReturnsFalse()
        {
            // Arrange
            // Creating an invalid showing by providing an invalid auditorium ID
            Showing showing = new Showing(DateTime.Now, TimeSpan.FromHours(10), TimeSpan.FromHours(11), -1, 1);

            // Act
            bool result = await showingManager.CreateAndInsertShowingAsync(showing);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task InsertReservationByShowingIdAsync_ValidReservation_ReturnsTrue()
        {
            // Arrange
            SeatReservation reservation = new SeatReservation(1, 1, 1, 2, 15);

            // Act
            bool result = await showingManager.InsertReservationByShowingIdAsync(reservation);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task InsertReservationByShowingIdAsync_InvalidReservation_ReturnsFalse()
        {
            // Arrange
            // Creating an invalid reservation by providing an invalid showing ID
            SeatReservation reservation = new SeatReservation(-1, 1, 1, 1, 1);

            // Act
            bool result = await showingManager.InsertReservationByShowingIdAsync(reservation);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task GetShowingsByAuditoriumIdAndDateAsync_ValidData_ReturnsShowingsList()
        {
            // Arrange
            int auditoriumId = 1;
            DateTime date = DateTime.Now;

            // Act
            List<Showing> showings = await showingManager.GetShowingsByAuditoriumIdAndDateAsync(auditoriumId, date);

            // Assert
            Assert.NotNull(showings);
            // Add additional assertions based on the expected data
        }

        [Fact]
        public async Task GetShowingsByAuditoriumIdAndDateAsync_InvalidData_ReturnsNull()
        {
            // Arrange
            int auditoriumId = -1;
            DateTime date = DateTime.Now;

            // Act
            List<Showing> showings = await showingManager.GetShowingsByAuditoriumIdAndDateAsync(auditoriumId, date);

            // Assert
            Assert.Empty(showings);
        }
    }
}
