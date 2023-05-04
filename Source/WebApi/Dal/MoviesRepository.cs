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

            string sqlInsert = @"INSERT INTO Movies (Title, Genre, Actors, Director, Producer, Language, Awards, ReleaseYear, Subtitles, SubtitlesLanguage, MPARatingEnum, Summary, RuntimeHours, RuntimeMinutes, Color, IMDbRating, IMDbLink, Dimension, PremierDate) 
             VALUES (@Title, @Genre, @Actors, @Director, @Producer, @Language, @Awards, @ReleaseYear, @Subtitles, @SubtitlesLanguage, @MPARatingEnum, @Summary, @RuntimeHours, @RuntimeMinutes, @Color, @IMDbRating, @IMDbLink, @Dimension, @PremierDate)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                numRowsAffected = await connection.ExecuteAsync(sqlInsert, movie);
            }

            return numRowsAffected == numRowsInserted;
        }
    }
}
