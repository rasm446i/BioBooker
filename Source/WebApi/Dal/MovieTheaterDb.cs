using BioBooker.Dml;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

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
            int numRowsInserted = 1;
            int numRowsAffected;

            string insertQuery = @"INSERT INTO MovieTheaters (Name) VALUES (@Name)";

            using (var connection = new SqlConnection(_connectionString))
            {
                numRowsAffected = await connection.ExecuteAsync(insertQuery, newMovieTheater);
            }
            return numRowsAffected == numRowsInserted;
        }
    }
}
