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
        private IMoviesManager moviesManager;

        public ViewMoviesView(IConfiguration configuration)
        {
            moviesManager = new MoviesManager(configuration);
            InitializeComponent();
            Load += ViewMoviesView_Load;
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

            string searchQuery = textBoxSearch.Text.Trim();

            List<Movie> movies = await moviesManager.GetAllMoviesAsync();

            // Add movie data to the ListView
            bool foundMovies = false;
            foreach (var movie in movies)
            {
                if (string.Equals(movie.Title, searchQuery, StringComparison.OrdinalIgnoreCase))
                {
                    var item = new ListViewItem(movie.Id.ToString());
                    item.SubItems.Add(movie.Title);
                    item.SubItems.Add(movie.Genre);
                    item.SubItems.Add(movie.RuntimeMinutes.ToString());
                    item.SubItems.Add(movie.MPARating);
                    listView1.Items.Add(item);
                    foundMovies = true;
                    // Break out of the loop if a matching movie is found
                    break;
                }
            }

            // If no movies matching the search query were found, display all movies
            if (!foundMovies)
            {
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

            // Display the MessageBox outside the loop
            if (!foundMovies)
            {
                MessageBox.Show("No movie was found with that title");
            }
        }




        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
