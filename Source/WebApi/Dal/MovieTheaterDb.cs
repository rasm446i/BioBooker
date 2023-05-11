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
    public class MovieTheaterDb : IMovieTheaterDb
    {
        private readonly string? _connectionString;

        private IConfiguration Configuration;

        public MovieTheaterDb(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("ConnectionString");
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

        private async Task<List<Seat>> GetAllSeatsFromAuditoriumIdAsync(int auditoriumId)
        {
            string query = "SELECT * FROM Seats WHERE AuditoriumId = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                List<Seat> seats = (await connection.QueryAsync<Seat>(query, new { Id = auditoriumId })).ToList();
                return seats;
            }
        }


        public async Task<List<MovieTheater>> GetAllMovieTheatersAsync()
        {
            List<MovieTheater> movieTheaters;
            string query = "SELECT * FROM MovieTheaters";

            using (var connection = new SqlConnection(_connectionString))
            {
                movieTheaters = (await connection.QueryAsync<MovieTheater>(query)).ToList();

                foreach (var movieTheater in movieTheaters)
                {
                    movieTheater.Auditoriums = await GetAllAuditoriumsFromMovieTheaterIdAsync(movieTheater.Id);

                    foreach (var auditorium in movieTheater.Auditoriums)
                    {
                        auditorium.Seats = await GetAllSeatsFromAuditoriumIdAsync(auditorium.AuditoriumId);
                    }
                }
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

        public async Task<bool> InsertAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool result = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        await CreateAndInsertAuditorium(newAuditorium, movieTheaterId, connection, transaction);
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

        public async Task<Auditorium> GetAuditoriumByIdAsync(int auditoriumId)
        {
            string query = "SELECT * FROM Auditorium WHERE AuditoriumId = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                var auditorium = (await connection.QueryAsync<Auditorium>(query, new { Id = auditoriumId })).FirstOrDefault();
                if (auditorium != null)
                {
                    auditorium.Seats = await GetAllSeatsFromAuditoriumIdAsync(auditorium.AuditoriumId);
                }
                return auditorium;
            }
        }


        public async Task<bool> CreateAndInsertAuditorium(Auditorium auditorium, int movieTheaterId, IDbConnection connection, IDbTransaction transaction)
        {
            int numRowsInserted = 0;

            string insertQuery = "INSERT INTO Auditorium (MovieTheaterId) VALUES (@MovieTheaterId); SELECT CAST(SCOPE_IDENTITY() as int)";

            int auditoriumId = await connection.ExecuteScalarAsync<int>(insertQuery, new { MovieTheaterId = movieTheaterId }, transaction);

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
            string insertQuery = @"INSERT INTO Seats (IsAvailable, SeatNumber, SeatRow, AuditoriumId) VALUES(@IsAvailable, @SeatNumber, @SeatRow, @AuditoriumId)";

            try
            {
                foreach (Seat seat in seats)
                {
                    await connection.ExecuteAsync(insertQuery, new { IsAvailable = seat.IsAvailable, SeatNumber = seat.SeatNumber, SeatRow = seat.SeatRow, AuditoriumId = auditoriumId }, transaction);
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


