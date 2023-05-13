using BioBooker.Dml;
using BioBooker.WinApp.Uil.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class CreateAuditoriumView : Form
    {
        private MovieTheater _selectedMovieTheater;
        public CreateAuditoriumView(MovieTheater movieTheater)
        {
            InitializeComponent();
            _selectedMovieTheater = movieTheater;
        }

        private async void btnCreateAuditorium_Click(object sender, EventArgs e)
        {
            // Get the data from the textboxes
            string seatRows = txtSeatRows.Text;
            string seatNumbers = txtSeatNumbers.Text;
            string auditoriumName = txtAuditoriumName.Text;

            // Try to parse input from row and seat
            int seatRowsParseResult = MovieTheaterController.TryParseRowAndSeatInput(seatRows);
            int seatsPerRowParseResult = MovieTheaterController.TryParseRowAndSeatInput(seatNumbers);

            // Validate auditorium name
            bool isValidAuditoriumName = MovieTheaterController.IsValidAuditoriumNameInputAndNotEmpty(auditoriumName);

            // Validate that the parsed results and auditorium name are valid
            if ((seatRowsParseResult != -1 && seatRowsParseResult > 0) && (seatsPerRowParseResult != -1 && seatsPerRowParseResult > 0) && isValidAuditoriumName)
            {
                // Generate the seats for the auditorium
                List<Seat> seats = MovieTheaterController.GetGeneratedSeats(seatRowsParseResult, seatsPerRowParseResult);

                // Create a new auditorium with the generated seats and auditorium name
                MovieTheaterController movieTheaterController = new MovieTheaterController();
                Auditorium newAuditorium = movieTheaterController.CreateAuditorium(seats, auditoriumName);

                // Add the new auditorium to the selected movie theater
                _selectedMovieTheater.Auditoriums.Add(newAuditorium);

                // Save changes in the database
                bool wasInserted = await movieTheaterController.AddAuditoriumToMovieTheaterAsync(_selectedMovieTheater.Id, newAuditorium);

                if (wasInserted)
                {
                    MessageBox.Show(newAuditorium.Name + " was added to " + _selectedMovieTheater.Name);
                }
                else
                {
                    MessageBox.Show(newAuditorium.Name + " was not inserted into the database");
                }
            }
            else
            {
                if (!isValidAuditoriumName)
                {
                    MessageBox.Show("Auditorium name can't be empty. The name has to contain letters and numbers with a space between them like so: Auditorium 1");
                }
                else
                {
                    MessageBox.Show("Amount of rows and seats must be an integer and higher than 0");
                }
            }
        }



    }

}

