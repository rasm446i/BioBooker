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
    public class MovieTheaterRepository : IMovieTheaterRepository
    {
        private readonly string? _connectionString;

        private IConfiguration Configuration;

        public MovieTheaterRepository(IConfiguration configuration)
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
                    foreach (Auditorium newAuditorium in newMovieTheater.Auditoriums)
                    {
                        await CreateAndInsertAuditoriumAsync(newAuditorium, movieTheaterId, connection, transaction);
                    }
                }

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
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
                        await CreateAndInsertAuditoriumAsync(newAuditorium, movieTheaterId, connection, transaction);
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


        public async Task<bool> CreateAndInsertAuditoriumAsync(Auditorium newAuditorium, int movieTheaterId, IDbConnection connection, IDbTransaction transaction)
        {
            string insertQuery = "INSERT INTO Auditorium (MovieTheaterId, Name) VALUES (@MovieTheaterId, @AuditoriumName); SELECT CAST(SCOPE_IDENTITY() as int)";

            int auditoriumId = await connection.ExecuteScalarAsync<int>(insertQuery, new { MovieTheaterId = movieTheaterId, AuditoriumName = newAuditorium.Name }, transaction);

            if (auditoriumId > 0)
            {
                if (newAuditorium.Seats != null && newAuditorium.Seats.Any())
                {
                    await CreateAndInsertSeatsAsync(newAuditorium.Seats, auditoriumId, connection, transaction);
                }
                return true;
            }

            return false;
        }

        public async Task<bool> InsertSeatsAsync(List<Seat> seats, int auditoriumId)
        {
            bool result = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        await CreateAndInsertSeatsAsync(seats, auditoriumId, connection, transaction);

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
        public async Task CreateAndInsertSeatsAsync(List<Seat> seats, int auditoriumId, IDbConnection connection, IDbTransaction transaction)
        {
            string insertQuery = @"INSERT INTO Seats ( SeatNumber, SeatRow, AuditoriumId) VALUES( @SeatNumber, @SeatRow, @AuditoriumId)";

            foreach (Seat seat in seats)
            {
                await connection.ExecuteAsync(insertQuery, new { SeatNumber = seat.SeatNumber, SeatRow = seat.SeatRow, AuditoriumId = auditoriumId }, transaction);
            }
        }

        public async Task<Auditorium> GetAuditoriumByNameAndMovieTheaterIdAsync(string auditoriumName, int movieTheaterId)
        {
            string query = "SELECT * FROM Auditorium WHERE Name = @Name AND MovieTheaterId = @MovieTheaterId";

            using (var connection = new SqlConnection(_connectionString))
            {
                Auditorium? foundAuditorium = (await connection.QueryAsync<Auditorium>(query, new { Name = auditoriumName, MovieTheaterId = movieTheaterId })).FirstOrDefault();
                if (foundAuditorium != null)
                {
                    foundAuditorium.Seats = await GetAllSeatsFromAuditoriumIdAsync(foundAuditorium.AuditoriumId);
                }
                return foundAuditorium;
            }
        }

    }
}

