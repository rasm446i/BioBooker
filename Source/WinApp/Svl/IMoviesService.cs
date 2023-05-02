using BioBooker.Dml;
using System.Collections.Generic;

namespace BioBooker.WinApp.Svl
{
    public interface IMoviesService
    {
        List<Movie> GetMovies();
        void AddMovie(Movie movieToAdd);
        Movie GetMovieById(int id);
        void UpdateMovie(int id);
        void DeleteMovie(int id);
        List<Movie> GetMovieByGenre(string genre);
    }
}