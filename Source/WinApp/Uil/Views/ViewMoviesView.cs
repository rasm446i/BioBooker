using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class ViewMoviesView : Form
    {
        private IConfiguration configuration;
        private IMoviesManager moviesManager;

        public ViewMoviesView(IConfiguration configuration)
        {
            this.configuration = configuration;
            moviesManager = new MoviesManager(configuration);
            InitializeComponent();
            Load += ViewMoviesView_Load;
            listView1.FullRowSelect = true;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        }

        /// <summary>
        /// Loads all the movies and disables the buttons if no movie is selected in the list view
        /// </summary>
        private async void ViewMoviesView_Load(object sender, EventArgs e)
        {

            // Call the GetAllMoviesAsync method to retrieve all movies
            List<Movie> listOfMovies = await moviesManager.GetAllMoviesAsync();

            // Add columns to the ListView
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Title");
            listView1.Columns.Add("Genre");
            listView1.Columns.Add("Runtime (Minutes)").Width = 120;
            listView1.Columns.Add("MPA Rating").Width = 120;


            // Add movie data to the ListView
            foreach (var movie in listOfMovies)
            {
                var item = new ListViewItem(movie.Id.ToString());
                item.SubItems.Add(movie.Title);
                item.SubItems.Add(movie.Genre);
                item.SubItems.Add(movie.RuntimeMinutes.ToString());
                item.SubItems.Add(movie.MPARating);
                listView1.Items.Add(item);
            }

            buttonSearch.Click += buttonSearch_Click;

            // Disables the buttons when no movie is selected
            buttonDelete.Enabled = false;
            buttonDetails.Enabled = false;
            buttonUpdateMovie.Enabled = false;
        }

        /// <summary>
        /// Searches for a movie by the written title. If no movie is found, a label will tell the user no movie is found
        /// and the list view will get all the movies again
        /// </summary>     
        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            labelNoMovieFound.Text = "";

            string searchQuery = textBoxSearch.Text.Trim();

            Movie matchingMovie = await moviesManager.GetMovieByTitleAsync(searchQuery);

            if (matchingMovie != null && matchingMovie.Title.Contains(searchQuery))
            {
                listView1.Items.Clear();
                var item = new ListViewItem(matchingMovie.Id.ToString());
                item.SubItems.Add(matchingMovie.Title);
                item.SubItems.Add(matchingMovie.Genre);
                item.SubItems.Add(matchingMovie.RuntimeMinutes.ToString());
                item.SubItems.Add(matchingMovie.MPARating);
                listView1.Items.Add(item);
            }
            else
            {
                List<Movie> movies = await moviesManager.GetAllMoviesAsync();
                listView1.Items.Clear();
                foreach (var movie in movies)
                {
                    var item = new ListViewItem(movie.Id.ToString());
                    item.SubItems.Add(movie.Title);
                    item.SubItems.Add(movie.Genre);
                    item.SubItems.Add(movie.RuntimeMinutes.ToString());
                    item.SubItems.Add(movie.MPARating);
                    listView1.Items.Add(item);
                }
            }

            if (matchingMovie == null)
            {
                labelNoMovieFound.Text = "No movie with that title found";
            }
        }

        /// <summary>
        /// Opens MovieDetailView when you select a movie in the list view and press the detail button
        /// </summary>
        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string title = selectedItem.SubItems[1].Text;

                MovieDetailView movieDetailView = new MovieDetailView(title, configuration);
                movieDetailView.Show();
            }
        }

        /// <summary>
        /// Enables the buttons whenever an item is selected in the list view, also disables when no item is selected
        /// </summary>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string title = selectedItem.SubItems[1].Text;
                buttonDetails.Enabled = true;
                buttonDelete.Enabled = true;
                buttonUpdateMovie.Enabled = true;
            } 
            else
            {
                buttonDetails.Enabled = false;
                buttonDelete.Enabled = false;
                buttonUpdateMovie.Enabled = false;
            }
        }

        /// <summary>
        /// Deletes the movie selected when pressing the delete button. A dialog will pop up requiring a confirmation from the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected movie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ListViewItem selectedItem = listView1.SelectedItems[0];
                    int id = int.Parse(selectedItem.SubItems[0].Text);

                    bool wasDeleted = await moviesManager.DeleteMovieByIdAsync(id);

                    if (wasDeleted)
                    {
                        // Remove movie from list view
                        listView1.Items.Remove(selectedItem);

                        MessageBox.Show("Movie deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the movie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a movie to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Opens a new view to update the selected movie
        /// </summary>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int id = int.Parse(selectedItem.SubItems[0].Text);
                string title = selectedItem.SubItems[1].Text;

                MovieUpdateView muv = new MovieUpdateView(id, title, configuration);
                muv.Show();
                this.Close();
            }
        }
    }
}