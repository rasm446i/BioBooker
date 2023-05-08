using BioBooker.Dml;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace BioBooker.WebApi.Dal
{
    public class MovieTheaterDb : IMovieTheaterDb
    {
        private readonly string? _connectionString;

        private IConfiguration Configuration;

        public MovieTheaterDb(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("BioBookerConnection");
        }

        public async Task<List<Auditorium>> GetAllAuditoriumsFromMovieTheaterIdAsync(int movieTheaterId)
        {
            string query = "SELECT * FROM Auditorium WHERE MovieTheaterId = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                List<Auditorium> auditoriums = (await connection.QueryAsync<Auditorium>(query, new { Id = movieTheaterId })).ToList();
                return auditoriums;
            }
        }

        public async Task<List<MovieTheater>> GetAllMovieTheatersAsync()
        {
            List<MovieTheater> movieTheaters;
            string query = "SELECT * FROM MovieTheaters";

            using (var connection = new SqlConnection(_connectionString))
            {

                movieTheaters = (await connection.QueryAsync<MovieTheater>(query)).ToList();

            }
            return movieTheaters;
        }

        public async Task<bool> InsertMovieTheaterAsync(MovieTheater newMovieTheater)
        {
            int numRowsInserted = 1;
            int numRowsAffected;

            string insertQuery = @"INSERT INTO MovieTheaters (Name) VALUES (@Name)";

            using (var connection = new SqlConnection(_connectionString))
            {
                numRowsAffected = await connection.ExecuteAsync(insertQuery, newMovieTheater);
            }
            return numRowsAffected == numRowsInserted;
        }

        public async Task<bool> InsertSeats(List<Seat> seats, int movieTheaterId, int auditoriumId)
        {
            int numRowsAffected;
            string insertQuery = @"INSERT INTO Seats (IsAvailable, SeatNumber, SeatRow, AuditoriumId, movieTheaterId) VALUES(@IsAvailable, @SeatNumber, @SeatRow, @AuditoriumId, @MovieTheaterId)";

            try
            {
                //Using statements ensures propper disposal of resources
                using (var connection = new SqlConnection(_connectionString))
                {
                    //This line is necessary even though Dapper opens and closes connections. DONT DELETE
                    await connection.OpenAsync();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            foreach (var seat in seats)
                            {
                                numRowsAffected = await connection.ExecuteAsync(insertQuery, new { SeatNumber = seat.SeatNumber, SeatRow = seat.SeatRow, IsAvailable = seat.IsAvailable, AuditoriumId = auditoriumId, MovieTheaterId = movieTheaterId }, transaction);

                                if (numRowsAffected <= 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine(ex.Message);
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }


}
    


