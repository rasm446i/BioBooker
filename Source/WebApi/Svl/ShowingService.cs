using BioBooker.Dml;
using BioBooker.WebApi.Dal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WebApi.Svl
{
    public class ShowingService : IShowingService
    {

        private readonly IShowingRepository _showingRepository;

        public ShowingService(IConfiguration configuration)
        {
            _showingRepository = new ShowingRepository(configuration);
        }

        public async Task<List<Showing>> GetAllShowingsAsync()
        {
            return await _showingRepository.GetAllShowingsAsync();
        }

        public async Task<bool> InsertShowingAsync(Showing showing)
        {
            return await _showingRepository.AddShowingAsync(showing);
        }

        public async Task<bool> InsertReservationByShowingId(SeatReservation reservation)
        {
            return await _showingRepository.InsertReservationByShowingId(reservation);
        }
    }
}
