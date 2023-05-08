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
            ValidateMovie(movie);
            bool movieExists = await CheckMovieExistsAsync(movie.Title, movie.ReleaseYear, movie.Director);
            if (movieExists)
            {
                throw new InvalidOperationException("A movie with the same title, release year, and director already exists.");
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int movieId = await InsertMovieAsync(connection, transaction, movie);
                        movie.Poster.MovieId = movieId;
                        await InsertPosterAsync(connection, transaction, movie.Poster);

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void ValidateMovie(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.MPARating))
            {
                throw new ArgumentException("MPA Rating is required.");
            }
        }

        private async Task<bool> CheckMovieExistsAsync(string title, string releaseYear, string director)
        {
            string sqlQuery = "SELECT COUNT(*) FROM Movies WHERE Title = @Title AND ReleaseYear = @ReleaseYear AND Director = @Director";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                int count = await connection.ExecuteScalarAsync<int>(sqlQuery, new { Title = title, ReleaseYear = releaseYear, Director = director });
                return count > 0;
            }
        }

        private async Task<int> InsertMovieAsync(SqlConnection connection, SqlTransaction transaction, Movie movie)
        {
            string sqlInsertMovies = @"INSERT INTO Movies (Title, Genre, Actors, Director, Language, ReleaseYear, Subtitles, SubtitlesLanguage, MPARating, RuntimeMinutes, PremierDate)
                              VALUES (@Title, @Genre, @Actors, @Director, @Language, @ReleaseYear, @Subtitles, @SubtitlesLanguage, @MPARating, @RuntimeMinutes, @PremierDate);
                              SELECT SCOPE_IDENTITY();";

            return await connection.ExecuteScalarAsync<int>(sqlInsertMovies, movie, transaction);
        }

        private async Task InsertPosterAsync(SqlConnection connection, SqlTransaction transaction, Poster poster)
        {
            // SQL statement to insert the poster into the Posters table
            // The ImageData column in the Posters table is a varbinary, which is used to store binary data (in this case the image)
            // To store the poster in the database, ImageData needs to be converted from a Base64-encoded string to binary format
            // This conversion ensures that the picture data is represented correctly before being stored in the ImageData column.
            string sqlInsertPosters = @"INSERT INTO Posters (MovieId, PosterTitle, ImageData)
                               VALUES (@MovieId, @PosterTitle, @ImageData);";

            var parameters = new
            {
                MovieId = poster.MovieId,
                PosterTitle = poster.PosterTitle,
                ImageData = poster.ImageData
            };

            await connection.ExecuteAsync(sqlInsertPosters, parameters, transaction);
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

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            string sqlQuery = "SELECT * FROM Movies";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var movies = await connection.QueryAsync<Movie>(sqlQuery);

                foreach (var movie in movies)
                {
                    DateTime releaseYear = DateTime.Parse(movie.ReleaseYear);
                    movie.ReleaseYear = releaseYear.ToString("yyyy-MM-dd");

                    DateTime premierDate = DateTime.Parse(movie.PremierDate);
                    movie.PremierDate = premierDate.ToString("yyyy-MM-dd");

                    // Retrieve the poster for each movie
                    string sqlPosterQuery = "SELECT * FROM Posters WHERE MovieId = @MovieId";
                    var posterParameters = new { MovieId = movie.Id };
                    var poster = await connection.QueryFirstOrDefaultAsync<Poster>(sqlPosterQuery, posterParameters);

                    if (poster != null)
                    {
                        movie.Poster = poster;
                    }
                }

                return movies.ToList();
            }
        }

    }
}
