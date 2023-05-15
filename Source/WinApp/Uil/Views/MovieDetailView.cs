using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class MovieDetailView : Form
    {
        private IMoviesManager moviesManager;
        private Movie movie;
        private readonly string title;

        public MovieDetailView(string title, IConfiguration configuration)
        {
            InitializeComponent();

            moviesManager = new MoviesManager(configuration);
            this.title = title;

            Load += MovieDetailView_Load;
        }

        // Retrieves the movie and displays the data and poster
        private async void MovieDetailView_Load(object sender, EventArgs e)
        {
            movie = await moviesManager.GetMovieByTitleAsync(title);
            if (movie != null)
            {
                DisplayMovieDetails();
                //ShowMoviePoster();
            }
            else
            {
                MessageBox.Show("Movie details not found.");
                Close();
            }
        }

        // Display the movie details in the form controls
        private async void DisplayMovieDetails()
        {
            labelReleaseYear.Text = movie.ReleaseYear;
            labelRuntime.Text = movie.RuntimeMinutes.ToString();
            labelLanguage.Text = movie.Language;
            labelTitle.Text = movie.Title;
            labelMPA.Text = movie.MPARating;
            labelGenre.Text = movie.Genre;
            labelDirector.Text = movie.Director;
            labelActors.Text = movie.Actors;
            labelSubtitles.Text = movie.Subtitles.ToString();
            labelSubtitlesLanguage.Text = movie.SubtitlesLanguage;
            pictureBox1.Image = Image.FromStream(new MemoryStream(movie.Poster.ImageData));

        }
    }
}
