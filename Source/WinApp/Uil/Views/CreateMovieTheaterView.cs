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

        private async void btnCreateMovieTheater_Click(object sender, EventArgs e)
        {
            string movieTheaterName = txtBoxMovieTheaterName.Text;
            string amountOfRows = txtBoxAmountOfRows.Text;
            string seatsPerRow = txtBoxSeatsPerRow.Text;

            int amountOfRowsParseResult = int.Parse(amountOfRows);
            int seatsPerRowParseResult = int.Parse(seatsPerRow);

            bool wasInserted;


            if (IsValidInput(amountOfRowsParseResult, seatsPerRowParseResult, movieTheaterName))
            {
                wasInserted = await movieTheaterController.CreateSeatsAndMovieTheaterFromUserInput(movieTheaterName, amountOfRowsParseResult, seatsPerRowParseResult);
                if (wasInserted)
                {
                    MessageBox.Show("Movie Theater has been created and inserted into the database");
                }
                else
                {
                    MessageBox.Show("Server error occurred: Movie Theater has NOT been created and inserted into the database");
                }
            }

        }
        private bool IsValidInput(int amountOfRowsParseResult, int seatsPerRowParseResult, string movieTheaterName)
        {

            if ((amountOfRowsParseResult < 1 || seatsPerRowParseResult < 1))
            {
                MessageBox.Show("Amount of rows and seats per row must be higher than 0");
                return false;

            }
            else if (String.IsNullOrEmpty(movieTheaterName) || !IsOnlyLetters(movieTheaterName))
            {
                MessageBox.Show("Movie theater name can't be empty and must only contain letters");
                return false;

            }
            return true;
        }

        private bool IsOnlyLetters(string movieTheaterName)
        {
            foreach (char character in movieTheaterName)
            {
                if (!char.IsLetter(character) && !char.IsWhiteSpace(character))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
