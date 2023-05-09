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
        private string hexImageData;
        public MovieDetailView(string title, IConfiguration configuration)
        {
            InitializeComponent();

            moviesManager = new MoviesManager(configuration);
            this.title = title;

            Load += MovieDetailView_Load;
        }

        public async Task<Movie> GetMovieByTitleAsync(string title)
        {
            return await moviesManager.GetMovieByTitleAsync(title);
        }

        private async void MovieDetailView_Load(object sender, EventArgs e)
        {
            movie = await moviesManager.GetMovieByTitleAsync(title);
            if (movie != null)
            {
                DisplayMovieDetails();
                ShowMoviePoster();
            }
            else
            {
                MessageBox.Show("Movie details not found.");
                Close();
            }
        }


        private async void DisplayMovieDetails()
        {
            // Display the movie details in the form controls
            labelReleaseYear.Text = movie.ReleaseYear;
            labelRuntime.Text = movie.RuntimeMinutes.ToString();
            labelPremierDate.Text = movie.PremierDate.ToString();
            labelLanguage.Text = movie.Language;
            labelTitle.Text = movie.Title;
            labelMPA.Text = movie.MPARating;
            labelGenre.Text = movie.Genre;
            labelDirector.Text = movie.Director;
            labelActors.Text = movie.Actors;
            labelSubtitles.Text = movie.Subtitles.ToString();
            labelSubtitlesLanguage.Text = movie.SubtitlesLanguage;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // USED TO SHOW THE POSTERS IN THE DATABASE
        
        private async void ShowMoviePoster()
        {
            string title =  labelTitle.Text;
            Movie movie = await moviesManager.GetMovieByTitleAsync(title);

            if (movie != null && movie.Poster != null)
            {
                byte[] imageData = movie.Poster.ImageData;
                hexImageData = ConvertByteArrayToHex(imageData);
                DisplayPoster();
            }
            else
            {
                MessageBox.Show("No poster found for the given movie title.");
            }
        }

        private string ConvertByteArrayToHex(byte[] byteArray)
        {
            string hexString = BitConverter.ToString(byteArray);
            return hexString.Replace("-", "");
        }

        private void DisplayPoster()
        {
            if (!string.IsNullOrEmpty(hexImageData))
            {
                byte[] imageData = ConvertHexToByteArray(hexImageData);
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private byte[] ConvertHexToByteArray(string hexString)
        {
            int length = hexString.Length;
            byte[] byteArray = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                byteArray[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }

            return byteArray;
        }
    }
}
