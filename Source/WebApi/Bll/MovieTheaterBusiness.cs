using BioBooker.Dml;
using BioBooker.WebApi.Svl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Bll
{
    public class MovieTheaterBusiness
    {

        private readonly IMovieTheaterServiceApi _movieTheaterServiceApi;
        public MovieTheaterBusiness(IConfiguration configuration)
        {
            _movieTheaterServiceApi = new MovieTheaterServiceApi(configuration);
        }

 

        public async Task<List<MovieTheater>> GetAllMovieTheaters()
        {
            List<MovieTheater> movieTheaterList = new List<MovieTheater>();
            
           return await _movieTheaterServiceApi.GetAllMovieTheaters();
           
        }           







    }
}
