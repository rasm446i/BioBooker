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

        /// <summary>
        /// Adds a movie to the database.
        /// </summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>A task representing the asynchronous operation. The task result is true if the movie was added successfully.</returns>
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

        /// <summary>
        /// Validates a movie object.
        /// </summary>
        /// <param name="movie">The movie to validate.</param>
        /// <exception cref="ArgumentException">Thrown when the MPA Rating is null or empty.</exception>
        private void ValidateMovie(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.MPARating))
            {
                throw new ArgumentException("MPA Rating is required.");
            }
        }

        /// <summary>
        /// Checks if a movie with the unique identifiers title, release year, and director already exists in the database.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        /// <param name="releaseYear">The release year of the movie.</param>
        /// <param name="director">The director of the movie.</param>
        /// <returns>A task representing the asynchronous operation. The task result is true if a movie with the specified details exists, false otherwise.</returns>
        private async Task<bool> CheckMovieExistsAsync(string title, string releaseYear, string director)
        {
            string sqlQuery = "SELECT COUNT(*) FROM Movies WHERE Title = @Title AND ReleaseYear = @ReleaseYear AND Director = @Director";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                int count = await connection.ExecuteScalarAsync<int>(sqlQuery, new { Title = title, ReleaseYear = releaseYear, Director = director });
                return count > 0;
            }
        }

        /// <summary>
        /// Inserts a movie into database in the Movies table.
        /// </summary>
        /// <param name="connection">The SqlConnection object used for the database connection.</param>
        /// <param name="transaction">The SqlTransaction object used for the database transaction.</param>
        /// <param name="movie">The movie to insert.</param>
        /// <returns>A task representing the asynchronous operation. The task result is the ID of the inserted movie.</returns>
        private async Task<int> InsertMovieAsync(SqlConnection connection, SqlTransaction transaction, Movie movie)
        {
            string sqlInsertMovies = @"INSERT INTO Movies (Title, Genre, Actors, Director, Language, ReleaseYear, Subtitles, SubtitlesLanguage, MPARating, RuntimeMinutes, PremierDate)
                              VALUES (@Title, @Genre, @Actors, @Director, @Language, @ReleaseYear, @Subtitles, @SubtitlesLanguage, @MPARating, @RuntimeMinutes, @PremierDate);
                              SELECT SCOPE_IDENTITY();";

            return await connection.ExecuteScalarAsync<int>(sqlInsertMovies, movie, transaction);
        }

        /// <summary>
        /// Inserts a poster into the database.
        /// </summary>
        /// <param name="connection">The SqlConnection object used for the database connection.</param>
        /// <param name="transaction">The SqlTransaction object used for the database transaction.</param>
        /// <param name="poster">The poster to insert.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task InsertPosterAsync(SqlConnection connection, SqlTransaction transaction, Poster poster)
        {
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

        /// <summary>
        /// Retrieves a movie from the database based on its title.
        /// </summary>
        /// <param name="title">The title of the movie to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The retrieved movie object, or null if no movie is found.</returns>
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

        /// <summary>
        /// Retrieves all movies from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result contains a list of Movie objects.</returns>
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
