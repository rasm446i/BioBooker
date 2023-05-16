using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Controllers
{
    public class MovieTheaterController
    {
        private IMovieTheaterManager _movieTheaterManager;
        public MovieTheaterController()
        {
            _movieTheaterManager = new MovieTheaterManager();
        }

        public async Task<bool> CreateSeatsAndMovieTheaterFromUserInputAsync(string movieTheaterName, int amountOfRows, int seatsPerRow, string auditoriumName)
        {
            // Generate seats based on the provided amount of rows and seats per row
            List<Seat> generatedSeats = GetGeneratedSeats(amountOfRows, seatsPerRow);

            // Create a movie theater with the provided name, generated seats and auditorium name
            bool wasInserted = await _movieTheaterManager.CreateMovieTheaterAndInsertAsync(movieTheaterName, generatedSeats, auditoriumName);

            return wasInserted;
        }


        public static List<Seat> GetGeneratedSeats(int amountOfRows, int seatsPerRow)
        {
            List<Seat> seats = new List<Seat>();

            // Iterate through each row
            for (int rowNum = 1; rowNum <= amountOfRows; rowNum++)
            {
                // Iterate through each seat in the row
                for (int seatNum = 1; seatNum <= seatsPerRow; seatNum++)
                {
                    // Create a new Seat with the row number and seat number, and add it to the list
                    seats.Add(new Seat(rowNum, seatNum));
                }
            }

            return seats;
        }

        public async Task<List<MovieTheater>> GetMovieTheaterListAsync()
        {
            return await _movieTheaterManager.GetMovieTheatersAsync();
        }

        public async Task<bool> AddAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasInserted = await _movieTheaterManager.AddAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

            return wasInserted;
        }

        public static bool IsOnlyLettersAndNotEmpty(string movieTheaterName)
        {
            if (!String.IsNullOrEmpty(movieTheaterName))
            {
                foreach (char character in movieTheaterName)
                {
                    if (!char.IsLetter(character) && !char.IsWhiteSpace(character))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public static bool IsValidAuditoriumNameInputAndNotEmpty(string auditoriumName)
        {
            bool hasWhitespaceBetweenLettersAndDigits = false;

            if (!String.IsNullOrEmpty(auditoriumName))
            {
                string input = auditoriumName;

                // Iterates through the characters of the auditorium name
                for (int currentIndex = 1; currentIndex < input.Length - 1; currentIndex++)
                {
                    // Stores the current, preceding and succeeding characters
                    char currentChar = input[currentIndex];
                    char precedingChar = input[currentIndex - 1];
                    char succeedingChar = input[currentIndex + 1];

                    // Verifies that the current character is a whitespace and the character before it is a letter and the character after it is a digit.
                    if (char.IsLetter(precedingChar) && char.IsDigit(succeedingChar) && currentChar == ' ')
                    {
                        hasWhitespaceBetweenLettersAndDigits = true;
                        break;
                    }
                    else
                    {
                        hasWhitespaceBetweenLettersAndDigits = false;
                    }

                }

            }
            // Returns true or false based on hasWhitespaceBetweenLettersAndDigits
            return hasWhitespaceBetweenLettersAndDigits;
        }

        public Auditorium CreateAuditorium(List<Seat> seats, string AuditoriumName)
        {
            return _movieTheaterManager.CreateAuditorium(seats, AuditoriumName);

        }
        public static int TryParseRowAndSeatInput(string input)
        {
            if (!int.TryParse(input, out int result))
            {
                return -1;
            }
            return result;
        }

        public static bool AuditoriumAlreadyAdded(Auditorium auditorium, List<Auditorium> audiList)
        {
            var insertName = auditorium.Name;

            foreach (var audi in audiList)
            {
                if (audi.Name == insertName)
                {
                    return true;
                }

            }

            return false;
        }


    }

}
