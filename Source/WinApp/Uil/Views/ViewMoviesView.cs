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

        private async void ViewMoviesView_Load(object sender, EventArgs e)
        {

            // Call the GetAllMoviesAsync method to retrieve all movies
            List<Movie> movies = await moviesManager.GetAllMoviesAsync();

            // Add columns to the ListView
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Title");
            listView1.Columns.Add("Genre");
            listView1.Columns.Add("Runtime (Minutes)").Width = 120;
            listView1.Columns.Add("MPA Rating").Width = 120;


            // Add movie data to the ListView
            foreach (var movie in movies)
            {
                var item = new ListViewItem(movie.Id.ToString());
                item.SubItems.Add(movie.Title);
                item.SubItems.Add(movie.Genre);
                item.SubItems.Add(movie.RuntimeMinutes.ToString());
                item.SubItems.Add(movie.MPARating);
                listView1.Items.Add(item);
            }

            buttonSearch.Click += buttonSearch_Click;
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            labelNoMovieFound.Text = "";

            string searchQuery = textBoxSearch.Text.Trim();

            Movie matchingMovie = await moviesManager.GetMovieByTitleAsync(searchQuery);

            if (matchingMovie != null)
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


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string title = selectedItem.SubItems[1].Text;
                buttonDetails.Enabled = true;
            } 
            else
            {
                buttonDetails.Enabled = false;
            }
        }

        private void ViewMoviesView_Load_1(object sender, EventArgs e)
        {

        }
    }
}
