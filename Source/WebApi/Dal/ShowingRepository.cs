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

        private IConfiguration Configuration;
        public ShowingRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("ConnectionString");
        }


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

        public async Task<bool> InsertShowingAsync(Showing showing, IDbConnection connection, IDbTransaction transaction)
        {
            int numRowsInserted = 0;

            string insertQuery = "INSERT INTO Showing (Date, StartTime, EndTime, AuditoriumId, MovieId) VALUES (@Date, @StartTime, @EndTime, @AuditoriumId, @MovieId)";

            numRowsInserted = await connection.ExecuteAsync(insertQuery, showing, transaction);

            return numRowsInserted > 0;
        }






        public async Task<bool> InsertSeats(List<Seat> seats, int auditoriumId)
        {
            bool result = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        await CreateAndInsertSeats(seats, auditoriumId, connection, transaction);

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
        public async Task CreateAndInsertSeats(List<Seat> seats, int auditoriumId, IDbConnection connection, IDbTransaction transaction)
        {
            string insertQuery = @"INSERT INTO Seats (SeatNumber, SeatRow, AuditoriumId) VALUES(@SeatNumber, @SeatRow, @AuditoriumId)";

            try
            {
                foreach (Seat seat in seats)
                {
                    await connection.ExecuteAsync(insertQuery, new { SeatNumber = seat.SeatNumber, SeatRow = seat.SeatRow, AuditoriumId = auditoriumId }, transaction);
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> InsertReservationByShowingId(int showingId, SeatReservation reservation)
        {
            bool result = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        await InsertReservationAsync(showingId, reservation, connection, transaction);
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

        // ADD IsReserved TO SEATS COLUMN??
        public async Task InsertReservationAsync(int showingId, SeatReservation reservation, IDbConnection connection, IDbTransaction transaction)
        {
            int numRowsInserted = 0;

            // Check if the seat is available
            bool isSeatAvailable = await IsSeatAvailableAsync(reservation.SeatNumber, reservation.SeatRow, reservation.AuditoriumId);

            if (!isSeatAvailable)
            {
                throw new Exception("The seat is already reserved.");
            }

            string insertQuery = "INSERT INTO Reservation (ShowingId, SeatNumber, SeatRow) VALUES (@ShowingId, @SeatNumber, @SeatRow)";

            numRowsInserted = await connection.ExecuteAsync(insertQuery, new { ShowingId = showingId, SeatNumber = reservation.SeatNumber, SeatRow = reservation.SeatRow }, transaction);

            if (numRowsInserted > 0)
            {
                // Update the IsReserved flag for the reserved seat
                await connection.ExecuteAsync("UPDATE Seats SET IsReserved = 1 WHERE SeatNumber = @SeatNumber AND SeatRow = @SeatRow AND AuditoriumId = @AuditoriumId", new { SeatNumber = reservation.SeatNumber, SeatRow = reservation.SeatRow, AuditoriumId = reservation.AuditoriumId }, transaction);
            }
            else
            {
                // Failed to insert reservation
                throw new Exception("Failed to insert reservation.");
            }
        }


        // Checking seat availability before reservation
        public async Task<bool> IsSeatAvailableAsync(int seatNumber, int seatRow, int auditoriumId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT IsReserved FROM Seats WHERE SeatNumber = @SeatNumber AND SeatRow = @SeatRow AND AuditoriumId = @AuditoriumId";

                bool isAvailable = await connection.QuerySingleOrDefaultAsync<bool>(query, new { SeatNumber = seatNumber, SeatRow = seatRow, AuditoriumId = auditoriumId });

                return !isAvailable;
            }
        }

    }


}
