using BioBooker.Dml;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        /// <summary>
        /// Inserts a reservation for a showing.
        /// </summary>
        /// <param name="reservation">The reservation to insert.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a value indicating whether the reservation was inserted successfully.</returns>
        public async Task<bool> InsertReservationByShowingId(SeatReservation reservation)
        {
            bool result = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        await InsertReservationAsync(reservation, connection, transaction);
                        transaction.Commit();
                        result = true;
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
        /// Inserts a reservation into the database.
        /// </summary>
        /// <param name="reservation">The reservation to insert.</param>
        /// <param name="connection">The database connection.</param>
        /// <param name="transaction">The transaction.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task InsertReservationAsync(SeatReservation reservation, IDbConnection connection, IDbTransaction transaction)
        {
            int numRowsInserted = 0;

            try
            {
                string insertQuery = "INSERT INTO SeatReservation (ShowingId, SeatNumber, SeatRow, AuditoriumId) VALUES (@ShowingId, @SeatNumber, @SeatRow, @AuditoriumId)";

                numRowsInserted = await connection.ExecuteAsync(insertQuery, new { ShowingId = reservation.ShowingId, SeatNumber = reservation.SeatNumber, SeatRow = reservation.SeatRow, AuditoriumId = reservation.AuditoriumId }, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to insert reservation.");
            }
        }

        public async Task<int> GetShowingIdByAuditoriumIdAndDateAndTimeAsync(int auditoriumId, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string selectQuery = "SELECT ShowingId FROM Showing WHERE AuditoriumId = @AuditoriumId AND Date = @Date AND StartTime = @StartTime AND EndTime = @EndTime";

                var parameters = new
                {
                    AuditoriumId = auditoriumId,
                    Date = date.Date,   
                    StartTime = startTime.ToString(@"HH\:mm\:ss"),   
                    EndTime = endTime.ToString(@"HH\:mm\:ss")        
                };

                return await connection.ExecuteScalarAsync<int>(selectQuery, parameters);
            }
        }

        public async Task<bool> BookSeatForShowing(SeatReservation seatReservation)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string selectQuery = "SELECT * FROM SeatReservation WHERE ShowingId = @ShowingId AND SeatRow = @SeatRow AND SeatNumber = @SeatNumber";
                        var existingReservation = await connection.QueryFirstOrDefaultAsync<SeatReservation>(selectQuery, new { ShowingId = seatReservation.ShowingId, SeatRow = seatReservation.SeatRow, SeatNumber = seatReservation.SeatNumber }, transaction);

                        if (existingReservation != null)
                        {
                            if (existingReservation.CustomerId == 0)
                            {
                                // Seat is not booked, update the seat reservation
                                string updateQuery = "UPDATE SeatReservation SET CustomerId = @CustomerId WHERE ShowingId = @ShowingId AND SeatRow = @SeatRow AND SeatNumber = @SeatNumber";
                                var rowsUpdated = await connection.ExecuteAsync(updateQuery, new { CustomerId = seatReservation.CustomerId, ShowingId = seatReservation.ShowingId, SeatRow = seatReservation.SeatRow, SeatNumber = seatReservation.SeatNumber }, transaction);

                                if (rowsUpdated > 0)
                                {
                                    transaction.Commit();
                                    return true;
                                }
                            }
                            else
                            {
                                // Seat is already booked
                                Console.WriteLine("The seat is already booked.");
                            }
                        }

                        transaction.Rollback();
                        return false;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }



    }
}
