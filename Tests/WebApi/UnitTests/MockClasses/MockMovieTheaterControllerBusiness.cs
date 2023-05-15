using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.UnitTests.MockClasses
{
    public class MockMovieTheaterControllerBusiness
    {
        
    public async Task<bool> InsertMovieTheaterAsync(MovieTheater movieTheater)
        {
            //simulates a succcessful insertion to the database
            return true;
        }
    }
}
