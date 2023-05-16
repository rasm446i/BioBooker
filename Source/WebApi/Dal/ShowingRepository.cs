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

        public async Task<List<Showing>> GetShowingsByAuditoriumIdAndDateAsync(int auditoriumId, DateTime date)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string selectQuery = "SELECT * FROM Showing WHERE AuditoriumId = @AuditoriumId AND Date = @Date";

                return (await connection.QueryAsync<Showing>(selectQuery, new { AuditoriumId = auditoriumId, Date = date })).ToList();
            }
        }


        public async Task<bool> InsertShowingAsync(Showing showing, IDbConnection connection, IDbTransaction transaction)
        {
            int showingId = 0;

            string insertQuery = "INSERT INTO Showing(Date, StartTime, EndTime, AuditoriumId, MovieId) VALUES(@Date, @StartTime, @EndTime, @AuditoriumId, @MovieId); SELECT SCOPE_IDENTITY()";

            showingId = await connection.ExecuteScalarAsync<int>(insertQuery, showing, transaction);


            // insert Seats I SeatRES

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


        private async Task<List<Seat>> GetAllSeatsFromAuditoriumIdAsync(int auditoriumId)
        {
            string query = "SELECT * FROM Seats WHERE AuditoriumId = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                List<Seat> seats = (await connection.QueryAsync<Seat>(query, new { Id = auditoriumId })).ToList();
                return seats;
            }
        }


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

        // ADD IsReserved TO SEATS COLUMN??
        public async Task InsertReservationAsync(SeatReservation reservation, IDbConnection connection, IDbTransaction transaction)
        {
            int numRowsInserted = 0;

            // Check if the seat is available 

            try
            {
                string insertQuery = "INSERT INTO SeatReservation (ShowingId, SeatNumber, SeatRow, AuditoriumId) VALUES (@ShowingId, @SeatNumber, @SeatRow, @AuditoriumId)";

                numRowsInserted = await connection.ExecuteAsync(insertQuery, new { ShowingId = reservation.ShowingId, SeatNumber = reservation.SeatNumber, SeatRow = reservation.SeatRow, AuditoriumId = reservation.AuditoriumId }, transaction);
            }
            catch(Exception ex)
            {
                // Failed to insert reservation
                throw new Exception("Failed to insert reservation.");
            }
        }



    }


}
