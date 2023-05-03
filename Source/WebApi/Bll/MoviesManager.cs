using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.WebApi.Svl;

namespace BioBooker.WebApi.Bll
{
    public class MoviesManager : IMoviesManager
    {
        private readonly IMoviesService _moviesService;

        public MoviesManager()
        {
            _moviesService = new MoviesService();
        }

    }
}
