using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.Dml;
using BioBooker.WebApi.Svl;
using Microsoft.Extensions.Configuration;

namespace BioBooker.WebApi.Bll
{
    public class MoviesManager
    {
        private readonly IMoviesService _moviesService;

        public MoviesManager(IConfiguration inConfiguration)
        {
            _moviesService = new MoviesService();
        }

        public bool InsertMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
