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
    public class ShowingManager: IShowingManager
    {
        private readonly IShowingService _showingService;

        //Constructor
        public ShowingManager(IConfiguration inConfiguration)
        {
            _showingService = new ShowingService(inConfiguration);
        }

        public async Task<bool> InsertShowingAsync(Showing showing)
        {
            return await _showingService.InsertShowingAsync(showing);
        }

    }
}
