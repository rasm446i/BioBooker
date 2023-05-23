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
using System.Globalization;

namespace BioBooker.WebApi.Dal
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly string _connectionString;
        private IConfiguration _configuration;
        public MoviesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }
        /// <summary>
        /// Adds a movie to the database.
        /// </summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>A task representing the asynchronous operation. The task result is true if the movie was added successfully.</returns>
        public async Task<bool> AddMovieAsync(Movie movie)
        {
            bool movieExists = await CheckMovieExistsAsync(movie.Title, movie.ReleaseYear, movie.Director, movie.Poster);
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
        /// Checks if a movie with the unique identifiers title, release year, and director already exists in the database.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        /// <param name="releaseYear">The release year of the movie.</param>
        /// <param name="director">The director of the movie.</param>
        /// <returns>A task representing the asynchronous operation. The task result is true if a movie with the specified details exists, false otherwise.</returns>
        private async Task<bool> CheckMovieExistsAsync(string title, string releaseYear, string director, Poster poster)
        {
            // Check if a movie with the specified title, release year, director, and poster exists
            string sqlQuery = @"SELECT COUNT(*) FROM Movies WHERE Title = @Title 
                                AND ReleaseYear = @ReleaseYear 
                                AND Director = @Director 
                                AND EXISTS ( SELECT 1 FROM Posters WHERE Posters.MovieId = Movies.Id 
                                AND PosterTitle = @PosterTitle )";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var parameters = new { Title = title, ReleaseYear = releaseYear, Director = director, PosterTitle = poster.PosterTitle };
                int count = await connection.ExecuteScalarAsync<int>(sqlQuery, parameters);
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
            string sqlInsertMovies = @"INSERT INTO Movies (Title, Genre, Actors, Director, Language, ReleaseYear, Subtitles, SubtitlesLanguage, MPARating, RuntimeMinutes)
                              VALUES (@Title, @Genre, @Actors, @Director, @Language, @ReleaseYear, @Subtitles, @SubtitlesLanguage, @MPARating, @RuntimeMinutes);
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

                //movie.ReleaseYear = movie.ReleaseYear.ToString();

                if (movie != null)
                {
                    // Format the ReleaseYear
                    if (!string.IsNullOrEmpty(movie.ReleaseYear))
                    {
                        int index = movie.ReleaseYear.IndexOf(" ");
                        if (index != -1)
                        {
                            movie.ReleaseYear = movie.ReleaseYear.Substring(0, index);
                        }
                    }

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
        /// Retrieves a movie from the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The retrieved movie object, or null if no movie is found.</returns>
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            string sqlQuery = @"SELECT * FROM Movies WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var parameters = new { Id = id };
                var movie = await connection.QueryFirstOrDefaultAsync<Movie>(sqlQuery, parameters);
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
            string sqlQuery = "SELECT m.*, @@DBTS AS RowVersion " +
                              "FROM Movies AS m";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var movies = await connection.QueryAsync<Movie>(sqlQuery);

                foreach (var movie in movies)
                {
                    // DateTime releaseYear = DateTime.Parse(movie.ReleaseYear);
                    movie.ReleaseYear = movie.ReleaseYear.ToString();

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

        /// <summary>
        /// Deletes a movie from the database.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        /// <returns>A task representing the asynchronous operation. The task result is true if the movie was deleted successfully.</returns>
        public async Task<bool> DeleteMovieByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sqlDeleteMovie = "DELETE FROM Movies WHERE Id = @Id";
                        await connection.ExecuteAsync(sqlDeleteMovie, new { Id = id }, transaction);

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

        public async Task<byte[]> ValidateMovieVersionByTitleAsync(int id)
        {
            byte[] version = null;
            string sqlQuery = @"SELECT Version
                        FROM Movies
                        WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var parameters = new { Id = id };
                version = await connection.ExecuteScalarAsync<byte[]>(sqlQuery, parameters);
            }

            return version;
        }

        /// <summary>
        /// Updates a movie in the database.
        /// </summary>
        /// <param name="id">The ID of the movie to update.</param>
        /// <param name="updatedMovie">The updated movie.</param>
        /// <returns>A task representing the asynchronous operation. The task result is true if the movie was updated successfully.</returns>
        public async Task<bool> UpdateMovieByIdAsync(int id, Movie updatedMovie)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    byte[] Version = await ValidateMovieVersionByTitleAsync(id);
                    if (updatedMovie.Version.SequenceEqual(Version))
                    {
                        try
                        {
                            updatedMovie.Id = id; // Set the ID of the updated movie
                            await UpdateMovieAsync(connection, transaction, updatedMovie);
                            await UpdatePosterAsync(connection, transaction, updatedMovie.Id, updatedMovie.Poster);

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                    else
                    {
                        transaction.Rollback();
                        throw new Exception("you dont have the newest version");
                    }
                }
            }

        }


        /// <summary>
        /// Updates the data of a movie in the Movies table.
        /// </summary>
        /// <param name="connection">The SqlConnection object used for the database connection.</param>
        /// <param name="transaction">The SqlTransaction object used for the database transaction.</param>
        /// <param name="movie">The movie to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task UpdateMovieAsync(SqlConnection connection, SqlTransaction transaction, Movie movie)
        {
            string sqlUpdateMovies = @"UPDATE Movies 
                                        SET 
                                        Title = @Title,
                                        Genre = @Genre,
                                        Actors = @Actors,
                                        Director = @Director,
                                        Language = @Language,
                                        ReleaseYear = @ReleaseYear,
                                        Subtitles = @Subtitles,
                                        SubtitlesLanguage = @SubtitlesLanguage,
                                        MPARating = @MPARating,
                                        RuntimeMinutes = @RuntimeMinutes
                                        WHERE Id = @Id";
            await connection.ExecuteAsync(sqlUpdateMovies, movie, transaction);
        }

        /// <summary>
        /// Updates the data of a poster in the Posters table.
        /// </summary>
        /// <param name="connection">The SqlConnection object used for the database connection.</param>
        /// <param name="transaction">The SqlTransaction object used for the database transaction.</param>
        /// <param name="poster">The poster to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task UpdatePosterAsync(SqlConnection connection, SqlTransaction transaction, int movieId, Poster updatedPoster)
        {
            string sqlUpdatePosters = @"UPDATE Posters SET
                                PosterTitle = @PosterTitle,
                                ImageData = @ImageData
                              WHERE MovieId = @MovieId";
            var parameters = new
            {
                PosterTitle = updatedPoster.PosterTitle,
                ImageData = updatedPoster.ImageData,
                MovieId = movieId
            };
            await connection.ExecuteAsync(sqlUpdatePosters, parameters, transaction);
        }



    }
}
