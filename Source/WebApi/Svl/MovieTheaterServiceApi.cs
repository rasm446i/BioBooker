using BioBooker.Dml;
using BioBooker.WebApi.Dal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BioBooker.WebApi.Svl
{
    public class MovieTheaterServiceApi : IMovieTheaterServiceApi
    {

        private readonly IMovieTheaterDb _movieTheaterDb;

        public MovieTheaterServiceApi(IConfiguration configuration) {
            _movieTheaterDb = new MovieTheaterDb(configuration);
        }


        public List<MovieTheater> getAllMovieTheaters()
        {
          List<MovieTheater> movieTheaterList = new List<MovieTheater>();    
            


            return movieTheaterList;   
        }



    }
}
