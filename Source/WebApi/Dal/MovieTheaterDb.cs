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


        public async Task<List<MovieTheater>> GetAllMovieTheaters()
        {
            var sql = "SELECT * FROM MovieTheaters";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var movieTheaters = (await connection.QueryAsync<MovieTheater>(sql)).ToList();

                return movieTheaters;
            }
        }





    }
}
