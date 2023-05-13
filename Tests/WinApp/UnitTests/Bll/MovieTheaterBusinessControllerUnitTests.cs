using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BioBooker.WinApp.IntegrationTests.Bll
{
    public class MovieTheaterBusinessControllerUnitTests
    {
        public class AuditoriumTests
        {
            [Fact]
            public void TestCreateAuditorium_AssignsAuditoriumNameAndSeatsCorrectly_WhenGivenValidInputs()
            {
                // Arrange
                string auditoriumName = "Aalborg Bio";
                MovieTheaterBusinessController _movieTheaterBusinessController = new MovieTheaterBusinessController();
                List<Seat> seats = new List<Seat>
                {
                //left is seat number & right is seat row
                new Seat(1, 1),
                new Seat(2, 1),
                new Seat(1, 2),
                new Seat(2, 2)
                 };


                // Act
               Auditorium auditorium = _movieTheaterBusinessController.CreateAuditorium(seats, auditoriumName);

                // Assert
                Assert.Equal(auditoriumName, auditorium.Name);
                Assert.Equal(seats.Count, auditorium.Seats.Count);
                Assert.Equal(seats[0].SeatNumber, auditorium.Seats[0].SeatNumber);
                Assert.Equal(seats[0].SeatRow, auditorium.Seats[0].SeatRow);
                Assert.Equal(seats[1].SeatNumber, auditorium.Seats[1].SeatNumber);
                Assert.Equal(seats[1].SeatRow, auditorium.Seats[1].SeatRow);
                Assert.Equal(seats[2].SeatNumber, auditorium.Seats[2].SeatNumber);
                Assert.Equal(seats[2].SeatRow, auditorium.Seats[2].SeatRow);
                Assert.Equal(seats[3].SeatNumber, auditorium.Seats[3].SeatNumber);
                Assert.Equal(seats[3].SeatRow, auditorium.Seats[3].SeatRow);
            }
        }


    }
}
