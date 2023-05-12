using BioBooker.Dml;
using BioBooker.WinApp.Uil.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class CreateAuditoriumView : Form
    {
        private MovieTheater selectedMovieTheater;
        public CreateAuditoriumView(MovieTheater movieTheater)
        {
            InitializeComponent();
            selectedMovieTheater = movieTheater;
        }

        private async void btnCreateAuditorium_Click(object sender, EventArgs e)
        {
            // Get the data from the form
            string seatRows = txtSeatRows.Text;
            string seatNumbers = txtSeatNumbers.Text;
            string auditoriumName = txtAuditoriumName.Text;

            //Try to parse input from row and seat
            int seatRowsParseResult = MovieTheaterController.TryParseRowAndSeatInput(seatRows);
            int seatNumbersParseResult = MovieTheaterController.TryParseRowAndSeatInput(seatNumbers);

            //Validate auditorium name
            bool isValidAuditoriumName = MovieTheaterController.IsValidAuditoriumNameInputAndNotEmpty(auditoriumName);

            //Validate that the parsed results and auditorium name are valid
            if (IsValidSeatsAndRowsInput(seatRowsParseResult) && IsValidSeatsAndRowsInput(seatNumbersParseResult) && isValidAuditoriumName)
            {
                // Generate the seats for the auditorium using the controller method
                List<Seat> seats = MovieTheaterController.GetGeneratedSeats(seatRowsParseResult, seatNumbersParseResult);

                // Create a new auditorium with the generated seats and auditorium name by using the CreateAuditorium method in the MovieTheaterController
                MovieTheaterController movieTheaterController = new MovieTheaterController();
                Auditorium newAuditorium = movieTheaterController.CreateAuditorium(seats, auditoriumName);

                // Add the new auditorium to the selected movie theater
                selectedMovieTheater.Auditoriums.Add(newAuditorium);

                // Save changes in the database
                bool wasInserted = await movieTheaterController.AddAuditoriumToMovieTheaterAsync(selectedMovieTheater.Id, newAuditorium);

                if (wasInserted)
                {
                    MessageBox.Show(newAuditorium.Name + " was added to " + selectedMovieTheater.Name);
                }
                else
                {
                    MessageBox.Show(newAuditorium.Name + " was not inserted into the database");
                }
            }


        }

        private bool IsValidSeatsAndRowsInput(int input)
        {
            if (input == -1)
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
