using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class CreateShowingView : Form
    {
        private Auditorium auditorium;
        private IShowingManager showingManager;
        private IMoviesManager moviesManager;
        private IConfiguration configuration;
        private string date;
        public CreateShowingView(string date, Auditorium auditorium, IConfiguration configuration)
        {
            InitializeComponent(); this.date = date;

            this.auditorium = auditorium;
            this.configuration = configuration;
            showingManager = new ShowingManager(configuration);
            moviesManager = new MoviesManager(configuration);
            labelDateString.Text = date;
            labelAuditoriumName.Text = auditorium.Name;
            LoadMovies();
            SetupTimeComboBoxes();
            comboBoxStartTime.SelectedIndexChanged += ComboBoxStartTime_SelectedIndexChanged;
            listViewMovies.SelectedIndexChanged += ListViewMovies_SelectedIndexChanged;
            textBoxEndTime.ReadOnly = true;
            buttonSubmit.Enabled = false;
        }

        /// <summary>
        /// Loads movies data into the ListView.
        /// </summary>
        private async void LoadMovies()
        {
            // Call the GetAllMoviesAsync method to retrieve all movies
            List<Movie> moviesList = await moviesManager.GetAllMoviesAsync();

            // Select the full row
            listViewMovies.FullRowSelect = true;

            // Add columns to the ListView
            listViewMovies.Columns.Add("Id");
            listViewMovies.Columns.Add("Title");
            listViewMovies.Columns.Add("Genre");
            listViewMovies.Columns.Add("Runtime (Minutes)").Width = 120;
            listViewMovies.Columns.Add("MPA Rating").Width = 120;


            // Add movie data to the ListView
            foreach (var movie in moviesList)
            {
                var item = new ListViewItem(movie.Id.ToString());
                item.SubItems.Add(movie.Title);
                item.SubItems.Add(movie.Genre);
                item.SubItems.Add(movie.RuntimeMinutes.ToString());
                item.SubItems.Add(movie.MPARating);
                listViewMovies.Items.Add(item);
            }
        }

        /// <summary>
        /// Sets up the start time and end time ComboBoxes with time values.
        /// </summary>
        private void SetupTimeComboBoxes()
        {
            // Populate the start time and end time ComboBoxes with time values

            for (int i = 10; i < 24; i++) // Iterates over hours (10 am to 23)
            {
                for (int j = 0; j < 60; j += 15) // Iterates over minutes, increments by 15 to have more choices
                {
                    string time = $"{i:00}:{j:00}:00"; // i:00 and j:00 ensures that hour and minute always has 2 digits along with 2 leading zeros
                                                       // (example: 09:05:00).
                    comboBoxStartTime.Items.Add(time);
                }
            }

            // Set default selected index for start time and end time ComboBoxes
            comboBoxStartTime.SelectedIndex = 0;

            comboBoxStartTime.Enabled = false;
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the button click event to submit a new showing.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (listViewMovies.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewMovies.SelectedItems[0];
                int movieId = int.Parse(selectedItem.SubItems[0].Text);

                // Get the selected start time and end time
                string selectedStartTime = comboBoxStartTime.SelectedItem.ToString();
                string selectedEndTime = textBoxEndTime.Text;

                // Parse the start time and end time to TimeSpan objects
                TimeSpan startTime = TimeSpan.Parse(selectedStartTime);
                TimeSpan endTime = TimeSpan.Parse(selectedEndTime);

                // Check if a showing with the same start time and end time already exists
                bool showingExists = await showingManager.ShowingExists(auditorium.AuditoriumId, startTime, endTime, DateTime.Parse(date));
                if (showingExists)
                {
                    MessageBox.Show("A showing with the same start time and end time already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a new Showing object
                Showing newShowing = new Showing(DateTime.Parse(date), startTime, endTime, auditorium.AuditoriumId, movieId);
                try
                {
                    // Call the CreateAndInsertShowingAsync method to save the new showing
                    bool success = await showingManager.CreateAndInsertShowingAsync(newShowing);
                    if (success)
                    {
                        // Showing saved successfully, display a success message
                        MessageBox.Show("Showing saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }catch (Exception exception)
                {
                    // Failed to save showing, display an error message
                    MessageBox.Show("Failed to save showing."+exception.Message, "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // No movie is selected, display an error message
                MessageBox.Show("Please select a movie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ComboBoxStartTime.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void ComboBoxStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMovies.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewMovies.SelectedItems[0];
                int movieRuntimeMinutes = int.Parse(selectedItem.SubItems[3].Text);

                // Get the selected start time
                string selectedStartTime = comboBoxStartTime.SelectedItem.ToString();

                // Calculate the end time
                DateTime startTime = DateTime.Parse(selectedStartTime);
                DateTime endTime = startTime.AddMinutes(movieRuntimeMinutes);

                if (endTime.Date > startTime.Date || endTime.TimeOfDay >= TimeSpan.FromDays(1))
                {
                    MessageBox.Show("The selected start time exceeds midnight and will go into the next day.", "Invalid Start Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxStartTime.SelectedIndex = 0; // Reset to the default start time option
                    return;
                }

                // Display the end time with the desired format
                // String literal (@) needed to format correctly and \: indicates that the colon
                // should be treated as a character rather than a formatting specifier
                textBoxEndTime.Text = endTime.ToString(@"HH\:mm\:ss");
                buttonSubmit.Enabled = true;
            }
        }


        /// <summary>
        /// Handles the SelectedIndexChanged event of the ListViewMovies.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void ListViewMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMovies.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewMovies.SelectedItems[0];
                int movieRuntimeMinutes = int.Parse(selectedItem.SubItems[3].Text);

                string selectedStartTime = comboBoxStartTime.SelectedItem.ToString();

                // Calculate the end time (start time + movie length)
                DateTime startTime = DateTime.Parse(selectedStartTime);
                DateTime endTime = startTime.AddMinutes(movieRuntimeMinutes);

                // Formatted to be a 24 hour clock. Example: 13:45:30
                textBoxEndTime.Text = endTime.ToString(@"HH\:mm\:ss");


                // Display movie title of selected movie
                labelMovieTitle.Text = selectedItem.SubItems[1].Text;

                comboBoxStartTime.Enabled = true;
                textBoxEndTime.ReadOnly = true;
            }
            else
            
                comboBoxStartTime.Enabled = false;
                textBoxEndTime.Text = string.Empty;
                buttonSubmit.Enabled = false;
            }
        }

    }

