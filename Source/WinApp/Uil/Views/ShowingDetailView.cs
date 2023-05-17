using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class ShowingDetailView : Form
    {

        private IShowingManager showingManager;
        private MoviesManager movieManager;
        private IConfiguration configuration;
        private Auditorium auditorium;
        private Movie movie;

        public ShowingDetailView(Auditorium auditorium, IConfiguration configuration)
        {
            InitializeComponent();
            this.configuration = configuration;
            showingManager = new ShowingManager(configuration);
            movieManager = new MoviesManager(configuration);
            this.auditorium = auditorium;
            Load += ShowingDetailView_Load;
            labelAuditorium.Text = auditorium.Name;
        }

        private void ShowingDetailView_Load(object? sender, EventArgs e)
        {

            // Add column headers
            listView1.Columns.Add("Movie Title").Width = 140;
            listView1.Columns.Add("Date").Width = 70;
            listView1.Columns.Add("Start Time").Width = 70;
            listView1.Columns.Add("End Time").Width = 70;
            
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;

            List<Showing> showings = await showingManager.GetShowingsByAuditoriumIdAndDateAsync(auditorium.AuditoriumId, selectedDate);

            listView1.Items.Clear();

            foreach (Showing showing in showings)
            {
                Movie movie = await movieManager.GetMovieByIdAsync(showing.MovieId); // Retrieve movie information

                ListViewItem item = new ListViewItem();
                item.Text = movie.Title; // Display the date
                item.SubItems.Add(showing.Date.ToShortDateString()); // Display the movie title
                item.SubItems.Add(showing.StartTime.ToString()); // Display the start time
                item.SubItems.Add(showing.EndTime.ToString()); // Display the end time
                

                listView1.Items.Add(item);
            }
        }



        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string selectedDateString = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Parse selectedDate to a string with the format "yyyy-MM-dd"

            CreateShowingView createShowingView = new CreateShowingView(selectedDateString, auditorium, configuration);
            createShowingView.ShowDialog();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
