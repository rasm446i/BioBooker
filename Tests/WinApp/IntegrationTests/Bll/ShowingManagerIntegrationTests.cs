using BioBooker.Dml;
using BioBooker.WebApi.Bll;
using BioBooker.WinApp.Bll;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;

namespace BioBooker.WinApp.Bll.Tests
{
    public class ShowingManagerIntegrationTests
    {
        private IConfiguration configuration;
        private IShowingManager showingManager;
        private readonly string _connectionString = "server=localhost; Database=BioBooker; integrated security=true;";
        private readonly string _sqlScript = @"DELETE FROM Showing
                                              WHERE Date = CONVERT(date, GETDATE()) AND
                                              StartTime = '10:00:00' AND
                                              EndTime = '11:00:00' AND
                                              AuditoriumId = 1 AND
                                              MovieId = 1;";

        public ShowingManagerIntegrationTests()
        {
            showingManager = new ShowingManager(configuration);
            
        }

        [Fact]
        public async Task CreateAndInsertShowingAsync_ValidShowing_ReturnsTrue()
        {
            ResetDatabase();
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

        private void ResetDatabase()
        {
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    connection.Execute(_sqlScript);
                    connection.Close();
                }
            }

        }
    }
}
