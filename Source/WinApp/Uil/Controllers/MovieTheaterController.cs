using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Uil.Controllers
{
    public class MovieTheaterController
    {
       private MovieTheaterBusinessController movieTheaterBusinessController;
       public MovieTheaterController()
        {
            movieTheaterBusinessController= new MovieTheaterBusinessController();
        }

        public async Task PassListOfSeatsToAuditoriumCreateAuditorium(string movieTheaterName, List<Seat> seats)
        {
            
           await movieTheaterBusinessController.CreateMovieTheater(movieTheaterName, seats);
        }
    }
}
