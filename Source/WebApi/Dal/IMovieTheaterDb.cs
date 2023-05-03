using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Dal
{
    public interface IMovieTheaterDb
    {
        public Task<List<MovieTheater>> getAllMovieTheaters();
    }
}
