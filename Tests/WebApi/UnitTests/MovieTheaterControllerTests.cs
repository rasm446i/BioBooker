using BioBooker.Dml;
using BioBooker.WebApi.Bll;
using BioBooker.WebApi.Ctl.Controllers;
using BioBooker.WebApi.UnitTests.MockClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BioBooker.WebApi.UnitTests
{
    public class MovieTheaterControllerTests
    {
        [Fact]

        public async Task Post_ValidMovieTheater_ReturnsCreated()
        {
            // Arrange
            var movieTheaterBusiness = new MockMovieTheaterControllerBusiness();
            var movieTheaterController = new MovieTheaterController(movieTheaterBusiness);

            var newMovieTheater = new MovieTheater
            {
                // Set the properties of the new movie theater object
            };

            // Act
            var result = await controller.Post(newMovieTheater);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result);
            var createdAtActionResult = (CreatedAtActionResult)result;
            Assert.AreEqual(nameof(MovieTheaterController.Post), createdAtActionResult.ActionName);
            Assert.AreSame(newMovieTheater, createdAtActionResult.Value);
        }
    }

    
}
