using BioBooker.Dml;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Dal
{
    public class ShowingRepository : IShowingRepository
    {
        private readonly string _connectionString;

        private IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowingRepository"/> class.
        /// </summary>
        /// <param name="configuration">The configuration object.</param>
        public ShowingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }

        /// <summary>
        /// Adds a new showing to the database.
        /// </summary>
        /// <param name="showing">The showing to add.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a value indicating whether the showing was added successfully.</returns>
        public async Task<bool> AddShowingAsync(Showing showing)
        {
            bool result = false;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        result = await InsertShowingAsync(showing, connection, transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        result = false;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Retrieves showings from the database based on the specified auditorium ID and date.
        /// </summary>
        /// <param name="auditoriumId">The ID of the auditorium.</param>
        /// <param name="date">The date of the showings.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a list of showings.</returns>
        public async Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string selectQuery = "SELECT * FROM Showing WHERE AuditoriumId = @AuditoriumId AND Date = @Date";

                return (await connection.QueryAsync<Showing>(selectQuery, new { AuditoriumId = auditoriumId, Date = date })).ToList();
            }
        }



        /// <summary>
        /// Retrieves all seats from the database for a given auditorium ID.
        /// </summary>
        /// <param name="auditoriumId">The ID of the auditorium.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a list of seats.</returns>
        private async Task<List<Seat>> GetAllSeatsFromAuditoriumIdAsync(int auditoriumId)
        {
            string query = "SELECT * FROM Seats WHERE AuditoriumId = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                List<Seat> seats = (await connection.QueryAsync<Seat>(query, new { Id = auditoriumId })).ToList();
                return seats;
            }
        }

        /// <summary>
        /// Inserts a showing into the database.
        /// </summary>
        /// <param name="showing">The showing to insert.</param>
        /// <param name="connection">The database connection.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a value indicating whether the showing was inserted successfully.</returns>
        private async Task<bool> InsertShowingAsync(Showing showing, IDbConnection connection, IDbTransaction transaction)
        {
            int showingId = 0;

            string insertQuery = "INSERT INTO Showing(Date, StartTime, EndTime, AuditoriumId, MovieId) VALUES(@Date, @StartTime, @EndTime, @AuditoriumId, @MovieId); SELECT SCOPE_IDENTITY()";

            showingId = await connection.ExecuteScalarAsync<int>(insertQuery, showing, transaction);

            List<Seat> seats = await GetAllSeatsFromAuditoriumIdAsync(showing.AuditoriumId);

            string insertQuerySeatRes = "INSERT INTO SeatReservation (ShowingId, AuditoriumId, SeatRow, SeatNumber, CustomerId) VALUES (@ShowingId, @AuditoriumId, @SeatRow, @SeatNumber, @CustomerId)";

            foreach (Seat seat in seats)
            {
                int customerId = 0;
                SeatReservation seatReservation = new SeatReservation(showing.AuditoriumId, seat.SeatRow, seat.SeatNumber, showingId, customerId);
                await connection.ExecuteAsync(insertQuerySeatRes, new { CustomerId = customerId, SeatRow = seat.SeatRow, SeatNumber = seat.SeatNumber, showing.AuditoriumId, ShowingId = showingId }, transaction);
            }
            return showingId > 0;
        }



        public async Task<bool> BookSeatForShowing(SeatViewModel seatViewModel)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (SeatReservation seatRes in seatViewModel.SeatReservations)
                        {
                            string getAvailability = @"SELECT *  
                                       FROM SeatReservation    
                                       WHERE ShowingId = @ShowingId 
                                       AND SeatRow = @SeatRow 
                                       AND SeatNumber = @SeatNumber";

                            var returnedData = await connection.QuerySingleOrDefaultAsync<SeatReservation>(getAvailability, seatRes, transaction);

                            if (returnedData != null && returnedData.CustomerId == 0)
                            {
                                string updateQuery = @"
                        UPDATE SeatReservation
                        SET CustomerId = @CustomerId
                        WHERE ShowingId = @ShowingId
                        AND SeatRow = @SeatRow
                        AND SeatNumber = @SeatNumber
                        AND CustomerId = 0";

                                var parameters = new
                                {
                                    seatRes.CustomerId,
                                    seatRes.ShowingId,
                                    seatRes.SeatRow,
                                    seatRes.SeatNumber,
                                };

                                var rowsUpdated = await connection.ExecuteAsync(updateQuery, parameters, transaction);

                                if (rowsUpdated == 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }








        public async Task<List<SeatReservation>> GetAllSeatReservationByShowingId(int showingId)
        {
            string sqlQuery = @"SELECT SeatRow, SeatNumber, ShowingId, CustomerId
                                FROM SeatReservation WHERE ShowingId = @ShowingId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var parameters = new { ShowingId = showingId };
                var result = await connection.QueryAsync<SeatReservation>(sqlQuery, parameters);
                return result.ToList();
            }
        }

    }

}