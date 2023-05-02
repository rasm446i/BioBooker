using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.WinApp.Svl;

namespace BioBooker.WinApp.Bll
{
    public class MovieTheaterController
    {
        readonly IMovieTheaterService _movieTheater;
    public MovieTheaterController() 
        {
            _movieTheater = new MovieTheaterService();
        }

    public MovieTheater createMovieTheater(string name, Auditorium auditorium)
        {
           MovieTheater newMovieTheater = new MovieTheater(name, auditorium);

            return new MovieTheater(name, auditorium);
        }
    
    public Auditorium createAuditorium(List<Seat> seats, int auditoriumNumber)
        {
            Auditorium newAuditorium = new Auditorium(seats, auditoriumNumber);
            return newAuditorium;
        }  

    }
}
