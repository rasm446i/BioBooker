using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class MovieDetailView : Form
    {
        private IMoviesManager moviesManager;
        public MovieDetailView(string title, IConfiguration configuration)
        {
            moviesManager = new MoviesManager(configuration);
            InitializeComponent();

            // Use the provided title to retrieve and display the movie details
            DisplayMovieDetails(title);
        }

        private async void DisplayMovieDetails(string title)
        {
            // Retrieve the movie details based on the title
            Movie movie = await GetMovieByTitle(title);

            // Display the movie details in the form controls
           /* labelReleaseYear.Text = movie.ReleaseYear;
            labelRuntime.Text = movie.RuntimeMinutes.ToString();
            labelPremierDate.Text = movie.PremierDate.ToString();
            labelLanguage.Text = movie.Language;
            labelTitle.Text = movie.Title;
            labelMPA.Text = movie.MPARating;
            labelGenre.Text = movie.Genre;
            labelDirector.Text = movie.Director;
            labelActors.Text = movie.Actors;
            labelSubtitles.Text = movie.Subtitles.ToString();
            labelSubtitlesLanguage.Text = movie.SubtitlesLanguage;*/

            // Add additional controls to display other movie details as needed
        }

        private async Task<Movie> GetMovieByTitle(string title)
        {
            // Implement the logic to retrieve the movie details from your data source
            // You can use the provided title to query your movie database or collection
            // and return the corresponding movie object
            // This is just a placeholder implementation, replace it with your actual logic
            return await moviesManager.GetMovieByTitleAsync(title);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
