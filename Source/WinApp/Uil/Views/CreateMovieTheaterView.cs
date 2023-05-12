using BioBooker.WinApp.Uil.Controllers;
using System;
using System.Drawing.Text;
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

        private async void btnCreateMovieTheater_Click(object sender, EventArgs e)
        {
            string movieTheaterName = txtBoxMovieTheaterName.Text;
            string amountOfRows = txtBoxAmountOfRows.Text;
            string seatsPerRow = txtBoxSeatsPerRow.Text;
            string auditoriumName = txtBoxAuditoriumName.Text;

            int amountOfRowsParseResult = MovieTheaterController.TryParseRowAndSeatInput(amountOfRows);
            int seatsPerRowParseResult = MovieTheaterController.TryParseRowAndSeatInput(seatsPerRow);

            bool isValidMovieTheaterName = MovieTheaterController.IsOnlyLettersAndNotEmpty(movieTheaterName);
            bool isValidAuditoriumName = MovieTheaterController.IsValidAuditoriumNameInputAndNotEmpty(auditoriumName);

            bool wasInserted;

            if(IsValidSeatsAndRowsInput(amountOfRowsParseResult) && IsValidSeatsAndRowsInput(seatsPerRowParseResult))
            {
                if (!isValidMovieTheaterName)
                {
                    MessageBox.Show("Movie theater name can't be empty and must only contain letters");

                }
                if (!isValidAuditoriumName)
                {
                    MessageBox.Show("Auditorium name can't be empty. Furthermore it must only contain letters, numbers and have a space between them. Like this: Auditorium 1");

                }
                else
                {
                    wasInserted = await movieTheaterController.CreateSeatsAndMovieTheaterFromUserInputAsync(movieTheaterName, amountOfRowsParseResult, seatsPerRowParseResult, auditoriumName);
                    if (wasInserted)
                    {
                        MessageBox.Show(movieTheaterName + " has been created and inserted into the database");
                    }
                    else
                    {
                        MessageBox.Show("Server error occurred: " + movieTheaterName + " has NOT been created and inserted into the database");
                    }
                }
            }
           

        }

        private bool IsValidSeatsAndRowsInput(int input)
        {
            if(input == -1)
            {
                MessageBox.Show("Amount of rows and seats must be an integer");
                return false;
            }
            else if (input <= 0)
            {
                MessageBox.Show("Seats and Rows must be higher than 0");
                return false;
            }
            return true;
        }

    }
}
