using BioBooker.Dml;
using BioBooker.WebApi.Bll;
using BioBooker.WebApi.Dal;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using IShowingManager = BioBooker.WebApi.Bll.IShowingManager;
using ShowingManager = BioBooker.WebApi.Bll.ShowingManager;

namespace BioBooker.WinApp.UnitTests.Bll
{
    public class ShowingManagerTests
    {
        private IShowingManager _showingManager;
        private IConfiguration _configuration;

        public ShowingManagerTests()
        {
            _showingManager = new ShowingManager(_configuration);
        }

        [Fact]
        public async Task BookSeatForShowing()
        {
            int auditoriumId = 1;
            int seatRow = 1;
            int seatNumber = 1;
            int showingId = 4;
            int customerId = 5;
            DateTime reservationDate = new DateTime(2023, 5, 15);
            TimeSpan reservationStartTime = new TimeSpan(12, 0, 0);
            TimeSpan reservationEndTime = new TimeSpan(14, 0, 0);

            SeatReservation reservation = new SeatReservation(auditoriumId, seatRow, seatNumber, showingId, customerId);
            IShowingManager repository = new ShowingManager(_configuration);

            // Act
            bool result = await repository.BookSeatForShowing(reservation);

            // Assert
            Assert.True(result);

        }

        [Fact]
        public void CreateShowing_ValidData_ReturnsNewShowing()
        {
            // Arrange
            DateTime date = DateTime.Now;
            TimeSpan startTime = TimeSpan.FromHours(10);
            TimeSpan endTime = TimeSpan.FromHours(11);
            int auditoriumId = 1;
            int movieId = 1;

            Showing expectedShowing = new Showing(date, startTime, endTime, auditoriumId, movieId);

            // Act

            /*Showing createdShowing = _showingManager.CreateShowing(expectedShowing);

            // Assert
            Assert.Equal(expectedShowing.Date, createdShowing.Date);
            Assert.Equal(expectedShowing.StartTime, createdShowing.StartTime);
            Assert.Equal(expectedShowing.EndTime, createdShowing.EndTime);
            Assert.Equal(expectedShowing.AuditoriumId, createdShowing.AuditoriumId);
            Assert.Equal(expectedShowing.MovieId, createdShowing.MovieId);*/
        }

        [Fact]
        public void CreateShowing_InvalidShowing_ThrowsArgumentException()
        {
            // Arrange
            IShowingManager showingManager = new ShowingManager(_configuration);
            DateTime date = DateTime.Now;
            TimeSpan startTime = TimeSpan.FromHours(10);
            TimeSpan endTime = TimeSpan.FromHours(8);  // Invalid: end time is before start time
            int auditoriumId = 1;
            int movieId = 1;
            Showing showing = new Showing(date, startTime, endTime, auditoriumId, movieId);

            // Act and Assert
           /* Assert.Throws<ArgumentException>(() =>
            {
                // This code should throw an ArgumentException
                showingManager.CreateShowing(showing);
            });*/
        }

    }
}
