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
    public class ShowingRepository: IShowingRepository
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

            string insertQuery = "INSERT INTO Showings (Date, StartTime, EndTime, AuditoriumId, MovieId) VALUES (@Date, @StartTime, @EndTime, @AuditoriumId, @MovieId)";

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
    }
}
