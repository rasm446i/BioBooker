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
        readonly IMovieTheaterService _movieTheaterService;
    public MovieTheaterController() 
        {
            _movieTheaterService = new MovieTheaterService();
        }
        public async Task<bool> CreateMovieTheater(string movieTheaterName, List<Seat> seats, int auditoriumNumber)
        {
            bool wasInserted;
            try
            {
                Auditorium newAuditorium = CreateAuditorium(seats, auditoriumNumber);
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
        public Auditorium CreateAuditorium(List<Seat> seats, int auditoriumNumber)
        {
            Auditorium newAuditorium = new Auditorium(seats, auditoriumNumber);
            return newAuditorium;
        }  

    }
}

/* VI DAPPER

// Access DB using Dapper
public class DbAccessShowing : IAccessShowing
{

    private readonly string _connectionString;

    private IConfiguration Configuration { get; set; }

    public DbAccessShowing()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["MovieExperienceConnection"].ToString();
    }

    public DbAccessShowing(IConfiguration configuration)
    {
        Configuration = configuration;
        _connectionString = Configuration.GetConnectionString("MovieExperienceConnection");
    }

    // For test project
    public DbAccessShowing(string testConnectionString)
    {
        _connectionString = testConnectionString;
    }

    // Get Showing by id
    public Showing GetShowingById(int showingNo)
    {
        string sqlSelectOne = "SELECT title, room, showTime, showingId FROM Showing_View WHERE showingId = @ShowingId";
        Showing foundShowing = null;
        using (SqlConnection movieConnection = new SqlConnection(_connectionString))
            // Dapper used - with parameter list
            foundShowing = movieConnection.QueryFirstOrDefault<Showing>(sqlSelectOne, new { ShowingId = showingNo });
        return foundShowing;
    }

    public List<SeatReservation> GetSeatReservationByShowingId(int showingNo)
    {
        string sqlSelectOne = "SELECT showingId, seatRow, seatNo, reserved, changeDate FROM SeatReservation_View WHERE showingId = @ShowingId";
        List<SeatReservation> foundReservations = null;
        using (SqlConnection movieConnection = new SqlConnection(_connectionString))
            // Dapper used - with parameter list
            foundReservations = movieConnection.Query<SeatReservation>(sqlSelectOne, new { ShowingId = showingNo }).ToList();
        return foundReservations;

    }

    // 
    public bool UpdateShowingReservations(int showingId, List<SeatReservation> newReservations)
    {
        int numRowsUpdated = 0;
        int numReservations = (newReservations != null) ? newReservations.Count : -1;
        // 
        string sqlUpdate = "UPDATE SeatReservation set reserved = 1, changeDate = @ResDate WHERE reserved = 0 AND showing_id = @ShowingId AND seatRow = @SeatRow AND seatNo = @SeatNo";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            foreach (SeatReservation sr in newReservations)
            {
                // Dapper used - with parameter list
                numRowsUpdated += connection.Execute(sqlUpdate,
                        new
                        {
                            ResDate = sr.ChangeDate,
                            ShowingId = showingId,
                            SeatRow = sr.SeatRow,
                            SeatNo = sr.SeatNo
                        });
            }
        }
        return (numRowsUpdated == numReservations);     // All reservations must be saved ok
    }

    public bool SetShowingReservation(int showingId, int seatRow, int seatNo, bool doReserve)
    {
        int numRowsToUpdate = 1;
        int numRowsUpdated;
        string sqlUpdate = "UPDATE SeatReservation set reserved = @ReserveValue WHERE showing_id = @ShowingId AND seatRow = @SeatRow AND seatNo = @SeatNo";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            // Dapper used - with parameter list
            numRowsUpdated = connection.Execute(sqlUpdate,
                    new
                    {
                        ReserveValue = doReserve,
                        ShowingId = showingId,
                        SeatRow = seatRow,
                        SeatNo = seatNo
                    });
        }
        return (numRowsUpdated == numRowsToUpdate);
    }

}
*/