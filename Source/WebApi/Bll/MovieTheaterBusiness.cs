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

        public async Task<bool> InsertMovieTheaterAsync(MovieTheater newMovieTheater)
        {
            bool wasInserted;

            wasInserted = await _movieTheaterServiceApi.InsertMovieTheaterAsync(newMovieTheater);

            return wasInserted;
        }

        public async Task<List<MovieTheater>> GetAllMovieTheatersAsync()
        {
           
           return await _movieTheaterServiceApi.GetAllMovieTheatersAsync();
           
        }

        public async Task<List<Auditorium>> GetAllAuditoriumsFromMovieTheaterIdAsync(int id)
        {
            return await _movieTheaterServiceApi.GetAllAuditoriumsFromMovieTheaterIdAsync(id);
        }
    }
}
