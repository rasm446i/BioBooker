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

        private readonly IShowingService _showingService;

        //Constructor
        public ShowingManager(IConfiguration configuration)
        {
            _showingService = new ShowingService(configuration);
        }


        public async Task<bool> CreateAndInsertShowingAsync(Showing showing)
        {
            bool inserted;
            try
            {
                Showing createdShowing = CreateShowing(showing);

                inserted = await _showingService.InsertShowingAsync(showing);
            }
            catch
            {
                inserted = false;
            }

            return inserted;
        }



        public Showing CreateShowing(Showing showing)
        {
            Showing newShowing = new Showing(showing.Date, showing.StartTime, showing.EndTime, showing.AuditoriumId, showing.MovieId);

            return newShowing;
        }
    }
}
