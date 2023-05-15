using BioBooker.WinApp.Uil.Controllers;
using System;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class CreateMovieTheaterView : Form
    {
        private MovieTheaterController movieTheaterController;
        public CreateMovieTheaterView()
        {
            InitializeComponent();
            movieTheaterController = new MovieTheaterController();
        }

        /**
         * Gets input data from CreateMovieTheaterView and validates it. It's then passed on to the MovieTheaterController 
         * to create a movie theater with an auditorium that contains seats. 
         */
        private async void btnCreateMovieTheater_Click(object sender, EventArgs e)
        {
            //Get input data
            string movieTheaterName = txtBoxMovieTheaterName.Text;
            string amountOfRows = txtBoxAmountOfRows.Text;
            string seatsPerRow = txtBoxSeatsPerRow.Text;
            string auditoriumName = txtBoxAuditoriumName.Text;

            //Parse amount of seats per row and amount of rows
            int seatRowsParseResult = MovieTheaterController.TryParseRowAndSeatInput(amountOfRows);
            int seatsPerRowParseResult = MovieTheaterController.TryParseRowAndSeatInput(seatsPerRow);

            //Validate input
            bool isValidMovieTheaterName = MovieTheaterController.IsOnlyLettersAndNotEmpty(movieTheaterName);
            bool isValidAuditoriumName = MovieTheaterController.IsValidAuditoriumNameInputAndNotEmpty(auditoriumName);

            bool wasInserted;

            if (seatRowsParseResult > 0 && seatsPerRowParseResult >= 1 && isValidMovieTheaterName && isValidAuditoriumName)
            {
                wasInserted = await movieTheaterController.CreateSeatsAndMovieTheaterFromUserInputAsync(movieTheaterName, seatRowsParseResult, seatsPerRowParseResult, auditoriumName);

                if (wasInserted)
                {
                    MessageBox.Show(movieTheaterName + " has been created and inserted into the database");
                }
                else
                {
                    MessageBox.Show("A server error occurred. " + movieTheaterName + " has NOT been created and inserted into the database");
                }
            }
            else
            {
                if (!isValidMovieTheaterName)
                {
                    MessageBox.Show("Movie theater name can't be empty and must only contain letters");
                }
                else if (!isValidAuditoriumName)
                {
                    MessageBox.Show("Auditorium name can't be empty. It must only contain letters, numbers, and have a space between them. For example: Auditorium 1");
                }
                else
                {
                    MessageBox.Show("There must be at least 1 row with more than 1 seat. Input must be an integer too.");
                }
            }
        }


    }
}
