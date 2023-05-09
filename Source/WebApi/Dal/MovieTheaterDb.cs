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
using System.Reflection.Metadata.Ecma335;

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
            bool result = false;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        result = await CreateAndInsertMovieTheaterAsync(newMovieTheater, connection, transaction);
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


        public async Task<bool> CreateAndInsertMovieTheaterAsync(MovieTheater newMovieTheater, IDbConnection connection, IDbTransaction transaction)
            {
                int numRowsInserted = 1;
                int numRowsAffected;
                int movieTheaterId = -1;
                try
                {
                    
                string insertQuery = @"INSERT INTO MovieTheaters (Name) VALUES (@Name); SELECT CAST(SCOPE_IDENTITY() as int)";

                    movieTheaterId = await connection.ExecuteScalarAsync<int>(insertQuery, newMovieTheater, transaction);

                    if (newMovieTheater.Auditoriums != null && newMovieTheater.Auditoriums.Any())
                    {
                        foreach (var audi in newMovieTheater.Auditoriums)
                        {
                            await CreateAndInsertAuditorium(audi, movieTheaterId, connection, transaction);
                        }
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                }

                return movieTheaterId >= 0;
            }

            public async Task<bool> InsertAuditorium(Auditorium auditorium, int movieTheaterId)
            {
                bool result = false;
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var transaction = await connection.BeginTransactionAsync())
                    {
                        try
                        {
                            await CreateAndInsertAuditorium(auditorium, movieTheaterId, connection, transaction);
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
        public async Task<bool> CreateAndInsertAuditorium(Auditorium auditorium, int movieTheaterId, IDbConnection connection, IDbTransaction transaction)
        {
            int numRowsInserted = 0;

            string insertQuery = "INSERT INTO Auditorium (MovieTheaterId) VALUES (@MovieTheaterId); SELECT CAST(SCOPE_IDENTITY() as int)";

            int auditoriumId = await connection.ExecuteScalarAsync<int>(insertQuery, new { MovieTheaterId = movieTheaterId }, transaction);

            if (auditoriumId > 0)
            {
                numRowsInserted = 1;
                await CreateAndInsertSeats(auditorium.Seats, movieTheaterId, auditoriumId, connection, transaction);
            }
            else
            {
                numRowsInserted = 0;
            }

            return numRowsInserted > 0;
        }


        public async Task<bool> InsertSeats(List<Seat> seats, int movieTheaterId, int auditoriumId)
            {
                bool result = false;
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var transaction = await connection.BeginTransactionAsync())
                    {
                        try
                        {
                            await CreateAndInsertSeats(seats, movieTheaterId, auditoriumId, connection, transaction);

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
        public async Task CreateAndInsertSeats(List<Seat> seats, int movieTheaterId, int auditoriumId, IDbConnection connection, IDbTransaction transaction)
        {
            string insertQuery = @"INSERT INTO Seats (IsAvailable, SeatNumber, SeatRow, AuditoriumId, movieTheaterId) VALUES(@IsAvailable, @SeatNumber, @SeatRow, @AuditoriumId, @MovieTheaterId)";

            try
            {
                foreach (Seat seat in seats)
                {
                    await connection.ExecuteAsync(insertQuery, new { IsAvailable = seat.IsAvailable, SeatNumber = seat.SeatNumber, SeatRow = seat.SeatRow, AuditoriumId = auditoriumId, MovieTheaterId = movieTheaterId }, transaction);
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


