using BioBooker.WebApp.Uil.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BioBooker.WebApp.UnitTests.Uil.Controllers;

public class HomeControllerTest
{
    [Fact]
    public void Index_IfCalled_ShouldReturnIndexView()
    {
        // Arrange
        var homeController = new HomeController();
        var expectedResult = "Index";

        // Act
        var viewResult = homeController.Index() as ViewResult;
        var actualResult = viewResult?.ViewName;

        // Assert
        Assert.Equal(expectedResult, actualResult);

    }
}
