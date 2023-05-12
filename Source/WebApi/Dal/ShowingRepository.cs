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
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                       await InsertShowingAsync(connection, transaction, showing);
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


        public async Task<bool> InsertShowingAsync(Auditorium auditorium, int movieTheaterId, IDbConnection connection, IDbTransaction transaction)
        {
            int numRowsInserted = 0;

            string insertQuery = @"INSERT INTO Showings (Date, StartTime, EndTime, AuditoriumId, MovieId) 
                                 VALUES (@Date, @StartTime, @EndTime, @AuditoriumId, @MovieÍd); SELECT CAST(SCOPE_IDENTITY() as int)";

            int auditoriumId = await connection.ExecuteScalarAsync<int>(insertQuery, new { ShowingId = movieTheaterId }, transaction);

            if (auditoriumId > 0)
            {
                numRowsInserted = 1;
                await CreateAndInsertSeats(auditorium.Seats, auditoriumId, connection, transaction);
            }
            else
            {
                numRowsInserted = 0;
            }

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
