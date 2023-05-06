using BioBooker.Dml;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Transactions;
using System.Reflection;

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
            int numRowsAffected;
            string sqlInsertMovies = @"INSERT INTO Movies (Title, Genre, Actors, Director, Language, ReleaseYear, Subtitles, SubtitlesLanguage, MPARatingEnum, RuntimeHours, RuntimeMinutes, PremierDate)
                    VALUES (@Title, @Genre, @Actors, @Director, @Language, @ReleaseYear, @Subtitles, @SubtitlesLanguage, @MPARatingEnum, @RuntimeHours, @RuntimeMinutes, @PremierDate);
                    SELECT SCOPE_IDENTITY();";

            string sqlInsertPosters = @"INSERT INTO Posters (MovieId, PosterTitle, ImageData)
                     VALUES (@MovieId, @PosterTitle, @ImageData);";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert the movie and retrieve the newly assigned movie ID
                        int movieId = await connection.ExecuteScalarAsync<int>(sqlInsertMovies, movie, transaction);

                        // Assign the movieId to the Poster object
                        movie.Poster.MovieId = movieId;

                        // Insert the poster
                        numRowsAffected = await connection.ExecuteAsync(sqlInsertPosters, movie.Poster, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return numRowsAffected > 0;
        }



        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            string sqlQuery = @"SELECT * FROM Movies WHERE Title = @Title";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var parameters = new { Title = title };
                var movie = await connection.QueryFirstOrDefaultAsync<Movie>(sqlQuery, parameters);
                DateTime releaseYear = DateTime.Parse(movie.ReleaseYear);
                movie.ReleaseYear = releaseYear.ToString("yyyy-MM-dd");

                DateTime premierDate = DateTime.Parse(movie.PremierDate);
                movie.PremierDate = premierDate.ToString("yyyy-MM-dd");

                if (movie != null)
                {
                    // Retrieve the poster for the movie
                    string sqlPosterQuery = @"SELECT * FROM Posters WHERE MovieId = @MovieId";
                    var posterParameters = new { MovieId = movie.Id };
                    var poster = await connection.QueryFirstOrDefaultAsync<Poster>(sqlPosterQuery, posterParameters);

                    if (poster != null)
                    {
                        movie.Poster = poster;
                    }
                }

                return movie;
            }
        }
    }
}
