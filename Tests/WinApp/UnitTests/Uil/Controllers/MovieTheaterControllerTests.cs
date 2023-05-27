using BioBooker.Dml;
using BioBooker.WinApp.Uil.Controllers;
using System;
using System.Collections.Generic;
using Xunit;


namespace BioBooker.WinApp.UnitTests.Uil.Controllers
{

    public class MovieTheaterControllerTests
    {
        private readonly MovieTheaterController _movieTheaterController;
        public MovieTheaterControllerTests()
        {
            _movieTheaterController = new MovieTheaterController();
        }
        [Fact]
        public void TestGetGeneratedSeatsFromMovieTheaterController_CreatesCorrectAmountOfSeats()
        {
            //arrange
            int amountOfRows = 5;
            int seatsPerRow = 2;

            //act
            List<Seat> seats = _movieTheaterController.GetGeneratedSeats(amountOfRows, seatsPerRow);

            //assert
            Assert.Equal(amountOfRows * seatsPerRow, seats.Count);
        }
        [Fact]
        public void TestGetGeneratedSeats_ReturnsSeatsWithCorrectRowAndSeatNumbers()
        {
            //arrange
            int amountOfRows = 3;
            int seatsPerRow = 3;

            //act
            List<Seat> seats = _movieTheaterController.GetGeneratedSeats(amountOfRows, seatsPerRow);

            //assert
            for (int rowNum = 1; rowNum <= amountOfRows; rowNum++)
            {
                for (int seatNum = 1; seatNum <= seatsPerRow; seatNum++)
                {
                    Assert.Contains(seats, seat => seat.SeatRow == rowNum && seat.SeatNumber == seatNum);
                }
            }
        }

        [Fact]
        public void TestIsOnlyLettersAndNotEmpty_WhenMovieTheaterNameIsNull_ReturnsFalse()
        {
            //arrange
            string movieTheaterName = null;

            //act
            bool result = MovieTheaterController.IsOnlyLettersAndNotEmpty(movieTheaterName);

            //assert
            Assert.False(result);
        }
        [Fact]
        public void TestIsOnlyLettersAndNotEmpty_WhenMovieTheaterNameIsEmpty_ReturnsFalse()
        {
            //arrange
            string movieTheaterName = "";

            //act
            bool result = MovieTheaterController.IsOnlyLettersAndNotEmpty(movieTheaterName);

            //assert
            Assert.False(result);
        }
        [Fact]
        public void TestIsOnlyLettersAndNotEmpty_WhenMovieTheaterNameContainsNonLetterCharacter_ReturnsFalse()
        {
            //arrange
            string movieTheaterName = "MovieTheater1";

            //act
            bool result = MovieTheaterController.IsOnlyLettersAndNotEmpty(movieTheaterName);

            //assert
            Assert.False(result);
        }
        [Fact]
        public void TestIsOnlyLettersAndNotEmpty_WhenMovieTheaterNameContainsOnlyLettersAndWhitespace_ReturnsTrue()
        {
            //arrange
            string movieTheaterName = "Movie Theater";

            //act
            bool result = MovieTheaterController.IsOnlyLettersAndNotEmpty(movieTheaterName);

            //assert
            Assert.True(result);

        }

        [Fact]
        public void TestTryParseRowAndSeatInput_WhenInputIsAnInteger_ReturnsParsedInteger()
        {
            //arrange
            string input = "5";

            //act
            int result = MovieTheaterController.TryParseRowAndSeatInput(input);

            //assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void TestTryParseRowAndSeatInput_WhenInputIsNotAnInteger_ReturnsMinusOne()
        {
            //arrange
            string input = "Text";

            //act
            int result = MovieTheaterController.TryParseRowAndSeatInput(input);

            //assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void TestTryParseRowAndSeatInput_WhenInputIsNull_ReturnsMinusOne()
        {
            //arrange
            string input = null;

            //act
            int result = MovieTheaterController.TryParseRowAndSeatInput(input);

            //assert
            Assert.Equal(-1, result);

        }

        [Fact]
        public void TestTryParseRowAndSeatInput_WhenInputIsEmpty_ReturnsMinusOne()
        {
            //arrange
            String input = "";

            //act
            int result = MovieTheaterController.TryParseRowAndSeatInput(input);

            //assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void TestIsValidAuditoriumNameInputAndNotEmpty_WhenNameIsNull_ReturnsFalse()
        {
            //arrange
            string auditoriumName = null;

            //act
            bool result = MovieTheaterController.IsValidAuditoriumNameInputAndNotEmpty(auditoriumName);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void TestIsValidAuditoriumNameInputAndNotEmpty_WhenNameIsEmpty_ReturnsFalse()
        {
            //arrange
            string auditoriumName = "";

            //act
            bool result = MovieTheaterController.IsValidAuditoriumNameInputAndNotEmpty(auditoriumName);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void TestIsValidAuditoriumNameInputAndNotEmpty_WhenNameHasNoSpaceBetweenLetterAndDigit_ReturnsFalse()
        {
            //arrange
            string auditoriumName = "Auditorium1";

            //act
            bool result = MovieTheaterController.IsValidAuditoriumNameInputAndNotEmpty(auditoriumName);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void TestIsValidAuditoriumNameInputAndNotEmpty_WhenNameHasSpaceBetweenLetterAndDigit_ReturnsTrue()
        {
            //arrange
            string auditoriumName = "Auditorium 1";

            //act
            bool result = MovieTheaterController.IsValidAuditoriumNameInputAndNotEmpty(auditoriumName);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void CreateAuditorium_ValidInput_CreatesAuditorium()
        {
            //arrange
            string auditoriumName = "Movie Theater";
            List<Seat> seats = new List<Seat>
            {
            //left is seat number & right is seat row
            new Seat(1, 1),
            new Seat(2, 1),
            new Seat(1, 2),
            new Seat(2, 2)
            };

            //act
            Auditorium newAuditorium = _movieTheaterController.CreateAuditorium(seats, auditoriumName);

            //assert
            Assert.Equal(auditoriumName, newAuditorium.Name);
            Assert.Equal(seats.Count, newAuditorium.Seats.Count);
            for (int seatIndex = 0; seatIndex < seats.Count; seatIndex++)
            {
                Assert.Equal(seats[seatIndex].SeatNumber, newAuditorium.Seats[seatIndex].SeatNumber);
                Assert.Equal(seats[seatIndex].SeatRow, newAuditorium.Seats[seatIndex].SeatRow);
            }
        }

    }
}
