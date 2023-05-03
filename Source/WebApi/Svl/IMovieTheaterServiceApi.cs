using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public interface IMovieTheaterServiceApi
    {
        public Task<List<MovieTheater>> GetAllMovieTheaters();

    }
}
