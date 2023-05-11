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
            int seatRows = int.Parse(txtSeatRows.Text);
            int seatNumbers = int.Parse(txtSeatNumbers.Text);

            if (IsValidInput(seatRows, seatNumbers))
            {
                // Generate the seats for the auditorium using the controller method
                List<Seat> seats = MovieTheaterController.GetGeneratedSeats(seatRows, seatNumbers);

                // Create a new auditorium with the generated seats
                Auditorium newAuditorium = new Auditorium(seats);

                // Add the new auditorium to the selected movie theater
                selectedMovieTheater.Auditoriums.Add(newAuditorium);

                // Save changes in the database
                MovieTheaterController movieTheaterController = new MovieTheaterController();
                await movieTheaterController.AddAuditoriumToMovieTheaterAsync(selectedMovieTheater.Id, newAuditorium);
            }


        }

        private bool IsValidInput(int seatRows, int seatNumbers)
        {
            // Check if either seatRows or seatNumbers is less than 1
            if ((seatRows < 1 || seatNumbers < 1))
            {
                // Display a message box indicating that the input is invalid
                MessageBox.Show("Amount of rows and seats per row must be higher than 0");

                // Return false to indicate that the input is not valid
                return false;
            }

            // Return true to indicate that the input is valid
            return true;
        }

    }

}
