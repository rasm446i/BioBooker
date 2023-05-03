using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.WinApp.Svl;

namespace BioBooker.WinApp.Bll
{
    public class MoviesManager : IMoviesManager
    {
        private readonly IMoviesService _moviesService;

        public MoviesManager()
        {
            _moviesService = new MoviesService();
        }


        public async Task<bool> CreateAndInsertMovieAsync(Movie movie)
        {
            Movie createdMovie = CreateMovie(movie);

            bool inserted = await _moviesService.InsertMovieAsync(createdMovie);

            return inserted;
        }

        public Movie CreateMovie(Movie movie)
        {
            Movie newMovie = new Movie(movie.Title, movie.Genre, movie.Actors, movie.Director, movie.Producer, movie.Language, movie.Awards, movie.ReleaseYear, movie.Subtitles, movie.SubtitlesLanguage, movie.MPARatingEnum, movie.Summary, movie.RuntimeHours, movie.RuntimeMinutes, movie.Color, movie.IMDbRating, movie.IMDbLink, movie.Dimension, movie.PremierDate);

            return newMovie;
        }


    }

}