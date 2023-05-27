using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class ShowingDetailView : Form
    {
        private IShowingManager showingManager;
        private MoviesManager movieManager;
        private IConfiguration configuration;
        private Auditorium auditorium;

        public ShowingDetailView(Auditorium auditorium, IConfiguration configuration)
        {
            InitializeComponent();
            this.configuration = configuration;
            showingManager = new ShowingManager(configuration);
            movieManager = new MoviesManager(configuration);
            this.auditorium = auditorium;
            Load += ShowingDetailView_Load;
            labelAuditorium.Text = auditorium.Name;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
        }

        /// <summary>
        /// Handles the Load event of the ShowingDetailView form.
        /// </summary>
        private async void ShowingDetailView_Load(object sender, EventArgs e)
        {
            // Add column headers
            listView1.Columns.Add("Movie Title").Width = 140;
            listView1.Columns.Add("Date").Width = 70;
            listView1.Columns.Add("Start Time").Width = 70;
            listView1.Columns.Add("End Time").Width = 70;

            DateTime selectedDate = dateTimePicker1.Value;
            await DisplayShowings(selectedDate);
        }

        /// <summary>
        /// Handles the ValueChanged event of the DateTimePicker1 control.
        /// </summary>
        private async void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            await DisplayShowings(selectedDate);
        }

        /// <summary>
        /// Displays the showings for the specified date.
        /// </summary>
        /// <param name="selectedDate">The selected date.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task DisplayShowings(DateTime selectedDate)
        {
            List<Showing> showings = await showingManager.GetShowingsByAuditoriumIdAndDateAsync(auditorium.AuditoriumId, selectedDate);

            listView1.Items.Clear();

            foreach (Showing showing in showings)
            {
                Movie movie = await movieManager.GetMovieByIdAsync(showing.MovieId);

                ListViewItem item = new ListViewItem();
                item.Text = movie.Title;
                item.SubItems.Add(showing.Date.ToShortDateString());
                item.SubItems.Add(showing.StartTime.ToString());
                item.SubItems.Add(showing.EndTime.ToString());

                listView1.Items.Add(item);
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonCreate control.
        /// </summary>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string selectedDateString = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Parse selectedDate to a string with the format "yyyy-MM-dd"

            CreateShowingView createShowingView = new CreateShowingView(selectedDateString, auditorium, configuration);
            createShowingView.ShowDialog();
        }

    }
}
