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

        /// <summary>
        /// Creates a certain amount of rows and seats per row based on input.
        /// Passes movie theater name, generated seats, and auditorium name to the CreateMovieTheaterAndInsertAsync
        /// method in the MovieTheaterManager class to create the movie theater.
        /// </summary>
        /// <param name="movieTheaterName">The name of the movie theater to be created.</param>
        /// <param name="amountOfRows">The number of rows in the auditorium.</param>
        /// <param name="seatsPerRow">The number of seats per row in the auditorium.</param>
        /// <param name="auditoriumName">The name of the auditorium within the movie theater.</param>
        /// <returns>A boolean indicating whether the movie theater was successfully created and inserted.</returns>
        public async Task<bool> CreateSeatsAndMovieTheaterFromUserInputAsync(string movieTheaterName, int amountOfRows, int seatsPerRow, string auditoriumName)
        {
            // Generate seats based on the provided amount of rows and seats per row
            List<Seat> generatedSeats = GetGeneratedSeats(amountOfRows, seatsPerRow);

            // Create a movie theater with the provided name, generated seats and auditorium name
            bool wasInserted = await _movieTheaterManager.CreateMovieTheaterAndInsertAsync(movieTheaterName, generatedSeats, auditoriumName);

            return wasInserted;
        }

        /// <summary>
        /// Gets the list of generated seats.
        /// </summary>
        /// <param name="amountOfRows">The number of rows in the auditorium.</param>
        /// <param name="seatsPerRow">The number of seats per row in the auditorium.</param>
        /// <returns>A list of seats.</returns>
        public List<Seat> GetGeneratedSeats(int amountOfRows, int seatsPerRow)
        {
           return _movieTheaterManager.GetGeneratedSeats(amountOfRows, seatsPerRow);
        }

        /// <summary>
        /// Retrieves a list of movie theaters from the database asynchronously.
        /// </summary>
        /// <returns>A task that holds a list of MovieTheater objects.</returns>
        public async Task<List<MovieTheater>> GetMovieTheaterListAsync()
        {
            return await _movieTheaterManager.GetMovieTheatersAsync();
        }

        /// <summary>
        /// Adds an auditorium to a movie theater asynchronously.
        /// </summary>
        /// <param name="movieTheaterId">The ID of the movie theater to which the auditorium will be added.</param>
        /// <param name="newAuditorium">The auditorium to be added to the movie theater.</param>
        /// <returns>A task that holds a boolean indicating whether the auditorium was successfully added or not.</returns>
        public async Task<bool> AddAuditoriumToMovieTheaterAsync(int movieTheaterId, Auditorium newAuditorium)
        {
            bool wasInserted = await _movieTheaterManager.AddAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

            return wasInserted;
        }

        /// <summary>
        /// Checks if the name of the MovieTheater only consists of letters and is not empty.
        /// </summary>
        /// <param name="movieTheaterName">The string to be checked.</param>
        /// <returns>True if the string consists only of letters, whitespace and is not empty. Otherwise it returns false.</returns>
        public static bool IsOnlyLettersAndNotEmpty(string movieTheaterName)
        {
            if (!String.IsNullOrEmpty(movieTheaterName))
            {
                foreach (char character in movieTheaterName)
                {
                    // Check if current charachter is not a letter or whitespace
                    if (!char.IsLetter(character) && !char.IsWhiteSpace(character))
                    {
                        // Returns false if something else than a letter and whitespace was found
                        return false;
                    }
                }
            }
            else
            {
                // Returns false if string is null or empty
                return false;
            }

            // Returns true if the string only contains letters and whitespace
            return true;
        }

        /// <summary>
        /// Checks if the auditorium name input is valid and not empty.
        /// The auditorium name is considered valid if it has a whitespace character between a letter and a digit.
        /// </summary>
        /// <param name="auditoriumName">The auditorium name to be checked.</param>
        /// <returns>True if the auditorium name input is valid and not empty. Otherwise it returns false.</returns>
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

        /// <summary>
        /// Passes the list of seats and auditorium name to the CreateAuditorium method
        /// in the MovieTheaterManager class to create an auditorium.
        /// </summary>
        /// <param name="seats">The list of seats to be included in the auditorium.</param>
        /// <param name="auditoriumName">The name of the auditorium.</param>
        /// <returns>The created auditorium.</returns>
        public Auditorium CreateAuditorium(List<Seat> seats, string AuditoriumName)
        {
            return _movieTheaterManager.CreateAuditorium(seats, AuditoriumName);

        }

        /// <summary>
        /// Tries to parse the input string as an integer representing the number of rows or seats.
        /// </summary>
        /// <param name="input">The input string to be parsed.</param>
        /// <returns>
        /// The parsed integer value if the parsing is successful.
        /// Otherwise it returns -1 to indicate the parsing has failed.
        /// </returns>
        public static int TryParseRowAndSeatInput(string input)
        {
            if (!int.TryParse(input, out int result))
            {
                return -1;
            }
            return result;
        }

        /// <summary>
        /// Checks if an auditorium with the same name has already been added to the ListBox of auditoriums.
        /// </summary>
        /// <param name="auditorium">The auditorium to be checked.</param>
        /// <param name="auditoriumList">The list of auditoriums to check.</param>
        /// <returns>True if an auditorium with the same name is found in the list. Otherwise it returns false.</returns>
        public static bool AuditoriumAlreadyAdded(Auditorium auditoriumToAddToListBox, List<Auditorium> auditoriumList)
        {
            string nameToCheck = auditoriumToAddToListBox.Name;

            foreach (var currentAuditorium in auditoriumList)
            {
                // Checks if the current auditoriums name in the list
                // is the same as the one that is being added
                if (currentAuditorium.Name == nameToCheck)
                {
                    // Returns true to indicate it already exists
                    return true;
                }

            }

            return false;
        }


    }

}
