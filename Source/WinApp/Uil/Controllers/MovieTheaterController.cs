using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Controllers
{
    public class MovieTheaterController
    {
        private MovieTheaterBusinessController movieTheaterBusinessController;
        public MovieTheaterController()
        {
            movieTheaterBusinessController = new MovieTheaterBusinessController();
        }

        public async Task<bool> CreateSeatsAndMovieTheaterFromUserInputAsync(string movieTheaterName, int amountOfRows, int seatsPerRow, string auditoriumName)
        {
            // Generate seats based on the provided amount of rows and seats per row
            List<Seat> generatedSeats = GetGeneratedSeats(amountOfRows, seatsPerRow);

            // Create a movie theater with the provided name, generated seats and auditorium name
            bool wasInserted = await movieTheaterBusinessController.CreateMovieTheaterAndInsertAsync(movieTheaterName, generatedSeats, auditoriumName);

            // Return the result indicating whether the movie theater and seats were successfully created and inserted
            return wasInserted;
        }


        public static List<Seat> GetGeneratedSeats(int amountOfRows, int seatsPerRow)
        {
            // Create a new list to store the generated seats
            List<Seat> seats = new List<Seat>();

            // Iterate through each row
            for (int rowNum = 1; rowNum <= amountOfRows; rowNum++)
            {
                // Iterate through each seat in the row
                for (int seatNum = 1; seatNum <= seatsPerRow; seatNum++)
                {
                    // Create a new Seat object with the row number and seat number, and add it to the list
                    seats.Add(new Seat(rowNum, seatNum));
                }
            }

            // Return the list of generated seats
            return seats;
        }

        public async Task<List<MovieTheater>> GetMovieTheaterListAsync()
        {
            return await movieTheaterBusinessController.GetMovieTheatersAsync();
        }

        public async Task<bool> AddAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasInserted = await movieTheaterBusinessController.AddAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

            return wasInserted;
        }

        public static bool IsValidRowsAndSeatsInput(int seatRows, int seatNumbers)
        {
            // Check if either seatRows or seatNumbers is less than 1
            if ((seatRows < 1 || seatNumbers < 1))
            {

                // Return false to indicate that the input is not valid
                return false;
            }

            // Return true to indicate that the input is valid
            return true;
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
            // Makes sure the auditorium isn't empty
            if (!String.IsNullOrEmpty(auditoriumName))
            {
                string input = auditoriumName;
                bool hasWhitespaceBetweenLettersAndDigits = false;

                // Iterates through the characters of the auditorium name
                for (int currentIndex = 1; currentIndex < input.Length - 1; currentIndex++)
                {
                    // Stores the current, preceding and succeeding characters
                    char currentChar = input[currentIndex];
                    char precedingChar = input[currentIndex - 1];
                    char succeedingChar = input[currentIndex + 1];

                    // Checks if the current character is a whitespace and its preceding and succeeding characters are a letter and a digit respectively
                    if (char.IsLetter(precedingChar) && char.IsDigit(succeedingChar) && currentChar == ' ')
                    {
                        hasWhitespaceBetweenLettersAndDigits = true;
                        // If so, it sets hasWhitespaceBetweenLettersAndDigits to true and breaks the loop
                        break;
                    }
                    else
                    {
                        // If not, it sets hasWhitespaceBetweenLettersAndDigits to false
                        hasWhitespaceBetweenLettersAndDigits = false;
                    }

                }
                // Returns true or false based on hasWhitespaceBetweenLettersAndDigits
                return hasWhitespaceBetweenLettersAndDigits;

            }
            else
            {
                MessageBox.Show("Auditorium name can't be empty");
                return false;
            }
        }

        public Auditorium CreateAuditorium(List<Seat> seats, string AuditoriumName)
        {
            return movieTheaterBusinessController.CreateAuditorium(seats, AuditoriumName);

        }
        public static int TryParseRowAndSeatInput(string input)
        {
            if (!int.TryParse(input, out int result))
            {
                return -1;
            }
            return result;
        }


    }

}
