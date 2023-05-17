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

        /// <summary>
        /// Retrieves all movie theaters from the database asynchronously.
        /// </summary>
        /// <returns>
        /// A task that holds a list of movie theaters.
        /// </returns>
        public async Task<List<MovieTheater>> GetAllMovieTheatersAsync()
        {
            List<MovieTheater> movieTheaters;
            string query = "SELECT * FROM MovieTheaters";

            using (var connection = new SqlConnection(_connectionString))
            {
                // Execute the SQL query and retrieve all movie theaters
                movieTheaters = (await connection.QueryAsync<MovieTheater>(query)).ToList();

                foreach (var movieTheater in movieTheaters)
                {
                    // Retrieve all auditoriums for the current movie theater
                    movieTheater.Auditoriums = await GetAllAuditoriumsFromMovieTheaterIdAsync(movieTheater.Id);

                    foreach (var auditorium in movieTheater.Auditoriums)
                    {
                        // Retrieve all seats for each auditorium
                        auditorium.Seats = await GetAllSeatsFromAuditoriumIdAsync(auditorium.AuditoriumId);
                    }
                }
            }

            return movieTheaters;
        }

        /// <summary>
        /// Retrieves all auditoriums within a movie theater from the database asynchronously.
        /// </summary>
        /// <param name="movieTheaterId">The ID of the movie theater.</param>
        /// <returns>
        /// A task that holds a list of auditoriums.
        /// </returns>
        public async Task<List<Auditorium>> GetAllAuditoriumsFromMovieTheaterIdAsync(int movieTheaterId)
        {
            string query = "SELECT * FROM Auditorium WHERE MovieTheaterId = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                // Execute the SQL query to retrieve all auditoriums that belong to the given movie theater ID
                List<Auditorium> auditoriums = (await connection.QueryAsync<Auditorium>(query, new { Id = movieTheaterId })).ToList();
                return auditoriums;
            }
        }

        /// <summary>
        /// Retrieves all seats within an auditorium from the database asynchronously.
        /// </summary>
        /// <param name="auditoriumId">The ID of the auditorium.</param>
        /// <returns>
        /// A task that holds a list of seats.
        /// </returns>
        private async Task<List<Seat>> GetAllSeatsFromAuditoriumIdAsync(int auditoriumId)
        {
            string query = "SELECT * FROM Seats WHERE AuditoriumId = @Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                // Execute the SQL query to retrieve all seats that belong to the specified auditorium ID
                List<Seat> seats = (await connection.QueryAsync<Seat>(query, new { Id = auditoriumId })).ToList();
                return seats;
            }
        }

        /// <summary>
        /// Inserts a new movie theater asynchronously.
        /// </summary>
        /// <param name="newMovieTheater">The new movie theater to be inserted into the database.</param>
        /// <returns>
        /// A task that holds a boolean value indicating whether the movie theater was successfully inserted or not.
        /// </returns>
        public async Task<bool> InsertMovieTheaterAsync(MovieTheater newMovieTheater)
        {
            bool result = false;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Begin the transaction
                using (var transaction = await connection.BeginTransactionAsync())
                {
                    try
                    {
                        // Call the CreateAndInsertMovieTheaterAsync method to perform the creation and insertion
                        result = await CreateAndInsertMovieTheaterAsync(newMovieTheater, connection, transaction);
                        // Commit the transaction if the operation is successful
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction if an exception occurs
                        transaction.Rollback();
                        result = false;
                    }
                }
            }

            return result;
        }


        /// <summary>
        /// Creates and inserts a new movie theater asynchronously.
        /// </summary>
        /// <param name="newMovieTheater">The new movie theater to be created and inserted.</param>
        /// <param name="connection">The database connection.</param>
        /// <param name="transaction">The database transaction.</param>
        /// <returns>
        /// A task that holds a boolean value indicating
        /// whether the movie theater was successfully created and inserted.
        /// </returns>
        public async Task<bool> CreateAndInsertMovieTheaterAsync(MovieTheater newMovieTheater, IDbConnection connection, IDbTransaction transaction)
        {
            int movieTheaterId = -1;

            try
            {
                // Insert the new movie theater and retrieve the generated movieTheaterId
                string insertQuery = @"INSERT INTO MovieTheaters (Name) VALUES (@Name); SELECT CAST(SCOPE_IDENTITY() as int)";

                // Execute the query and retrieve the generated movieTheaterId
                movieTheaterId = await connection.ExecuteScalarAsync<int>(insertQuery, newMovieTheater, transaction);

                    // Check if the movie theater has any auditoriums
                if (newMovieTheater.Auditoriums != null && newMovieTheater.Auditoriums.Any())
                {
                    // If the new movie theater has auditoriums, iterate through them and insert each one
                    foreach (Auditorium newAuditorium in newMovieTheater.Auditoriums)
                    {
                        await CreateAndInsertAuditoriumAsync(newAuditorium, movieTheaterId, connection, transaction);
                    }
                }
            }
            catch (Exception ex)
            {
                // Rollback if any exceptions occurs
                transaction.Rollback();
                return false;
            }

            // Return true if the movieTheaterId is valid
            return movieTheaterId > 0;
        }


        /// <summary>
        /// Creates and inserts a new auditorium into the database asynchronously.
        /// </summary>
        /// <param name="newAuditorium">The new auditorium to be created and inserted.</param>
        /// <param name="movieTheaterId">The ID of the movie theater to which the auditorium belongs.</param>
        /// <param name="connection">The database connection.</param>
        /// <param name="transaction">The database transaction.</param>
        /// <returns>
        /// A task that holds a boolean value indicating whether the auditorium was successfully created and inserted or not.
        /// </returns>
        public async Task<bool> CreateAndInsertAuditoriumAsync(Auditorium newAuditorium, int movieTheaterId, IDbConnection connection, IDbTransaction transaction)
        {
            string insertQuery = "INSERT INTO Auditorium (MovieTheaterId, Name) VALUES (@MovieTheaterId, @AuditoriumName); SELECT CAST(SCOPE_IDENTITY() as int)";

            // Execute the query and retrieve the generated auditoriumId
            int auditoriumId = await connection.ExecuteScalarAsync<int>(insertQuery, new { MovieTheaterId = movieTheaterId, AuditoriumName = newAuditorium.Name }, transaction);

            if (auditoriumId > 0)
            {
                    // Check if the auditorium has any seats
                if (newAuditorium.Seats != null && newAuditorium.Seats.Any())
                {
                    // If the new auditorium has seats, call the CreateAndInsertSeatsAsync method to create and insert each seat
                    await CreateAndInsertSeatsAsync(newAuditorium.Seats, auditoriumId, connection, transaction);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates and inserts a list of seats into the database asynchronously.
        /// </summary>
        /// <param name="seats">The list of seats to be created and inserted.</param>
        /// <param name="auditoriumId">The ID of the auditorium to which the seats belong.</param>
        /// <param name="connection">The database connection.</param>
        /// <param name="transaction">The database transaction.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CreateAndInsertSeatsAsync(List<Seat> seats, int auditoriumId, IDbConnection connection, IDbTransaction transaction)
        {
            string insertQuery = @"INSERT INTO Seats (SeatNumber, SeatRow, AuditoriumId) VALUES (@SeatNumber, @SeatRow, @AuditoriumId)";

            foreach (Seat seat in seats)
            {
                // Execute the query to insert each seat into the Seats table
                await connection.ExecuteAsync(insertQuery, new { SeatNumber = seat.SeatNumber, SeatRow = seat.SeatRow, AuditoriumId = auditoriumId }, transaction);
            }
        }

        //Not being used currently
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

        //Not being used currently
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

        //Not being used currently
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

    }
}

