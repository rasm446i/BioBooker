using BioBooker.Dml;
using BioBooker.WinApp.Svl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Bll
{
    public class ShowingManager : IShowingManager
    {

        private readonly IShowingService _ShowingService;
        public ShowingManager(IConfiguration configuration)
        {
            _ShowingService = new ShowingService(configuration);
        }

        // Creates a movie and inserts it along with the associated poster into the sql database.
        // Returns a boolean value indicating whether the movie insertion was successful.
        public async Task<bool> CreateAndInsertShowingAsync(Auditorium auditorium, Showing showing)
        {
            bool inserted;
            try
            {

            }
            catch
            {
                inserted = false;
            }

            return inserted;
        }



        public Movie CreateMovie(Showing showing, Auditorium auditorium)
        {
            Showing newShowing = new Showing(showing.movie, auditorium.Seats);

            return newShowing;
        }
    }
}
