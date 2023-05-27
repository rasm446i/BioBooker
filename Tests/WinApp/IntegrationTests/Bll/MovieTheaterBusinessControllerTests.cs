using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;
using static Dapper.SqlMapper;

namespace BioBooker.WinApp.IntegrationTests.Bll
{
    public class MovieTheaterBusinessControllerTests
    {
        private readonly string _connectionString = "server=.\\SQLExpress; Database=BioBooker; integrated security=true;";
        private readonly string _sqlScript = @"DELETE FROM MovieTheaters WHERE Name = 'MovieTheater'";
        private MovieTheaterManager _movieTheaterManager;

        public MovieTheaterBusinessControllerTests()
        {
            _movieTheaterManager = new MovieTheaterManager();
        }

        [Fact]
        public async Task CreateMovieTheaterAndInsertAsync_ReturnsTrue_WhenMovieTheaterHasBeenInserted()
        {

            ResetDatabase();
            //arrange
            string movieTheaterName = "MovieTheater";
            string auditoriumName = "Auditorium 1";
            List<Seat> seats = new List<Seat>
            {
            new Seat(1, 1),
            new Seat(1, 2),
            new Seat(2, 1),
            new Seat(2, 2)
            };

            //act
            bool result = await _movieTheaterManager.CreateMovieTheaterAndInsertAsync(movieTheaterName, seats, auditoriumName);

            //assert
            Assert.True(result);

            ResetDatabase();
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