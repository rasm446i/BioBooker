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
    public class MoviesRepository : IMoviesRepository
    {
        private readonly string _connectionString;

        private IConfiguration Configuration;

        public MoviesRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("ConnectionString");
        }


        public async Task<bool> AddMovieAsync(Movie movie)
        {
            int numRowsInserted = 1;
            int numRowsAffected;

            string sqlInsert = @"INSERT INTO Movies (Id, Title, Genre, Actors, Director, Language, ReleaseYear, Subtitles, SubtitlesLanguage, MPARatingEnum, RuntimeHours, RuntimeMinutes, PremierDate) 
             VALUES (@Id, @Title, @Genre, @Actors, @Director, @Language, @ReleaseYear, @Subtitles, @SubtitlesLanguage, @MPARatingEnum, @RuntimeHours, @RuntimeMinutes, @PremierDate)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                numRowsAffected = await connection.ExecuteAsync(sqlInsert, movie);
            }

            return numRowsAffected == numRowsInserted;
        }

        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQuery = @"SELECT * FROM Movies WHERE Title = @title";
                var parameters = new { Title = title };
                var result = await connection.QuerySingleOrDefaultAsync<Movie>(sqlQuery, parameters);
                return result;
            }
        }

    }
}
