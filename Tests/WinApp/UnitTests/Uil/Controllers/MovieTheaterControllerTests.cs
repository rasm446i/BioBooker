using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.Dml;
using BioBooker.WinApp.Uil.Controllers;
using Xunit;


namespace BioBooker.WinApp.UnitTests.Uil.Controllers
{

    public class MovieTheaterControllerTests
    {
        [Fact]
        public void GetGeneratedSeatsFromMovieTheaterController()
        {
            //arrange
            int amountOfRows = 5;
            int seatsPerRow = 2;
            
            //act
            List<Seat> seats = MovieTheaterController.GetGeneratedSeats(amountOfRows, seatsPerRow);

            //assert
            Assert.Equal(amountOfRows * seatsPerRow, seats.Count);
        }

    }
}
