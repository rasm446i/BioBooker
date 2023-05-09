using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBooker.WinApp.Svl;

namespace BioBooker.WinApp.Bll
{
    public class MovieTheaterBusinessController
    {
        readonly IMovieTheaterService _movieTheaterService;
    public MovieTheaterBusinessController() 
        {
            _movieTheaterService = new MovieTheaterService();
        }
        public async Task<bool> CreateMovieTheater(string movieTheaterName, List<Seat> seats)
        {
            bool wasInserted;
            try
            {
                Auditorium newAuditorium = await CreateAuditorium(seats);

                MovieTheater newMovieTheater = new MovieTheater(movieTheaterName, newAuditorium);
                wasInserted = await InsertMovieTheaterAsync(newMovieTheater);
            }
            catch (Exception ex)
            {
            wasInserted = false;
            }
            return wasInserted;
        }
        public async Task<bool> InsertMovieTheaterAsync(MovieTheater movieTheater)
        {
            bool wasInserted = await _movieTheaterService.InsertMovieTheaterAsync(movieTheater);
         
            return wasInserted;
        }
        public async Task<Auditorium> CreateAuditorium(List<Seat> seats)
        {
            return await Task.FromResult(new Auditorium(seats));
        }  

    }
}