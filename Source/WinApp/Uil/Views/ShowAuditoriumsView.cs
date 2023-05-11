using BioBooker.Dml;
using BioBooker.WinApp.Uil.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class ShowAuditoriumsView : Form
    {
        MovieTheaterController movieTheaterController;
        public ShowAuditoriumsView()
        {
            InitializeComponent();
            movieTheaterController = new MovieTheaterController();
            AddMovieTheatersToListBoxAsync();

        }

        private async Task AddMovieTheatersToListBoxAsync()
        {
            // Retrieve the list of movie theaters asynchronously from the database
            List<MovieTheater> movieTheaters = await movieTheaterController.GetMovieTheaterListAsync();

            // Iterate through each movie theater in the list
            foreach (MovieTheater movieTheater in movieTheaters)
            {
                // Add the movie theater to the ListBoxOfMovieTheaters
                ListBoxOfMovieTheaters.Items.Add(movieTheater);
            }
        }

        private void ListBoxOfMovieTheaters_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear the listbox of auditoriums when changing index
            ListBoxOfAuditoriums.Items.Clear();
            
            //Get the selected movie theater
            MovieTheater selectedMovieTheater = (MovieTheater)ListBoxOfMovieTheaters.SelectedItem;

            //Check if a movie theater is selected
            if(selectedMovieTheater != null)
            {
                //Add the auditoriums of the selected movie theater to the list box of auditoriums

                foreach (Auditorium auditorium in selectedMovieTheater.Auditoriums)
                {
                    ListBoxOfAuditoriums.Items.Add(auditorium);
                }
            }

        }

        private void ListBoxOfAuditoriums_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected auditorium
            Auditorium selectedAuditorium = (Auditorium)ListBoxOfAuditoriums.SelectedItem;

            // Check if an auditorium is selected
            if (selectedAuditorium != null)
            {
                // Calculate the seat information
                int seatRows = selectedAuditorium.Seats.Max(s => s.SeatRow);
                int seatNumbers = selectedAuditorium.Seats.Max(s => s.SeatNumber);
                int totalSeats = selectedAuditorium.Seats.Count;

                // Update the text fields with the seat information
                lblSeatRows.Text = seatRows.ToString();
                lblSeatNumbers.Text = seatNumbers.ToString();
                lblTotalSeats.Text = totalSeats.ToString();

            }
            else
            {
                // Clear the text fields
                lblSeatRows.Text = string.Empty;
                lblSeatNumbers.Text = string.Empty;
                lblTotalSeats.Text = string.Empty;
            }
        }

        private void btnAddAuditorium_Click(object sender, EventArgs e)
        {
            // Get the selected movie theater from the ListBoxOfMovieTheaters
            MovieTheater selectedMovieTheater = (MovieTheater)ListBoxOfMovieTheaters.SelectedItem;

            // Check if a movie theater is selected
            if (selectedMovieTheater != null)
            {
                // Open the auditorium view to create a new auditorium and pass the selected movie theater
                CreateAuditoriumView createAuditoriumView = new CreateAuditoriumView(selectedMovieTheater);
                createAuditoriumView.ShowDialog();

                // Refresh the auditorium list
                ListBoxOfAuditoriums.Items.Clear();
                foreach (Auditorium auditorium in selectedMovieTheater.Auditoriums)
                {
                    ListBoxOfAuditoriums.Items.Add(auditorium);
                }
            }
        }

    }
}
