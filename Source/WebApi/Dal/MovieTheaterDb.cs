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

            using(var connection = new SqlConnection(_connectionString))    
            using(var transaction = await connection.BeginTransactionAsync())
            {
                try
                {
                    await CreateAndInsertMovieTheaterAsync(newMovieTheater);
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
            return result;
        }


        public async Task<bool> CreateAndInsertMovieTheaterAsync(MovieTheater newMovieTheater, IDbConnection connection)
        {
            int numRowsInserted = 1;
            int numRowsAffected;
            int movieTheaterId = -1;
            try
            {
                string insertQuery = @"INSERT INTO MovieTheaters (Name) VALUES (@Name)";

                using (connection)
                {
                    movieTheaterId = (int)await connection.ExecuteScalarAsync(insertQuery, newMovieTheater);

                }

                Auditorium? audi = newMovieTheater.Auditoriums.FirstOrDefault();
                if (audi != null)
                    await InsertAuditorium(audi, movieTheaterId);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return movieTheaterId >= 0;
        }

        public async Task<bool> InsertAuditorium(Auditorium auditorium, int movieTheaterId)
        {
            bool result = false;

            using (var connection = new SqlConnection(_connectionString))
            using (var transaction = await connection.BeginTransactionAsync())
            {
                try
                {
                    await CreateAndInsertAuditorium(auditorium, movieTheaterId);
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
            return result;

        }

        public async Task<bool> CreateAndInsertAuditorium(Auditorium auditorium, int movieTheaterId)
        {
            int numRowsAffected = 0;
            int MovieTheaterId = auditorium.AuditoriumId;


            string insertQuery = @"INSERT INTO Auditorium (MovieTheaterId) VALUES(@movieTheaterId)";




            return numRowsAffected <= 0;
        }

        public async Task<bool> InsertSeats(List<Seat> seats, int movieTheaterId, int auditoriumId)
        {
            bool result = false;

            using (var connection = new SqlConnection(_connectionString))
            using (var transaction = await connection.BeginTransactionAsync())
            {
                try
                {
                    await CreateAndInsertSeats(seats, movieTheaterId, auditoriumId);

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
            return result;
        }

        public async Task<bool> CreateAndInsertSeats(List<Seat> seats, int movieTheaterId, int auditoriumId)
        {
           string insertQuery = @"INSERT INTO Seats (IsAvailable, SeatNumber, SeatRow, AuditoriumId, movieTheaterId) VALUES(@IsAvailable, @SeatNumber, @SeatRow, @AuditoriumId, @MovieTheaterId)";

            try
            {

                

            }catch (Exception ex) { }

        }
    }


}
    


//TODO Ændre så at i hirakiet kalder den ikke Insert men Create And Insert