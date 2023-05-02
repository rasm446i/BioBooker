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

        public MoviesManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public object AddMovieAsync(Movie movie)
        {
            return _movieRepository.AddMovieAsync(movie);
        }

    }

}
