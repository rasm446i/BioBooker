using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class MovieUpdateView : Form
    {
        private string? selectedImagePath;
        private IConfiguration configuration;
        private IMoviesManager moviesManager;
        private CreateMovieView cmv;
        private ViewMoviesView vmv;
        private Movie preUpdatedMovie; // Added field to store pre-updated movie data
        
        private int movieId;
        private string movieTitle;
        

        public MovieUpdateView(int id, string title, IConfiguration configuration)
        {
            this.configuration = configuration;
            cmv = new CreateMovieView(configuration);
            vmv = new ViewMoviesView(configuration);
            moviesManager = new MoviesManager(configuration);
            movieId = id;
            movieTitle = title;
            this.selectedImagePath = cmv.GetSelectedImagePath();
            InitializeComponent();
            InitializeComboBoxes();
            IntializeCheckedListBox();
            LoadPreUpdatedMovie();
        }

        // Load the pre-updated movie data
        private async void LoadPreUpdatedMovie()
        {
            preUpdatedMovie = await moviesManager.GetMovieByTitleAsync(movieTitle);
            if (preUpdatedMovie != null)
            {
                // Populate the textboxes, poster, and comboboxes with pre-updated movie data
                txtTitle.Text = preUpdatedMovie.Title;
                comboBoxGenre.SelectedItem = preUpdatedMovie.Genre;
                txtActors.Text = preUpdatedMovie.Actors;
                txtDirector.Text = preUpdatedMovie.Director;
                comboBoxLanguage.SelectedItem = preUpdatedMovie.Language;
                dateTimePickerReleaseYear.Value = DateTime.Parse(preUpdatedMovie.ReleaseYear);
                comboBoxMpaRating.SelectedItem = preUpdatedMovie.MPARating;
                textBoxRunTime.Text = preUpdatedMovie.RuntimeMinutes.ToString();
                dateTimePickerPremierDate.Value = DateTime.Parse(preUpdatedMovie.PremierDate);
                pictureBox1.Image = Image.FromStream(new MemoryStream(preUpdatedMovie.Poster.ImageData));

                if (preUpdatedMovie.Subtitles == 1)
                {
                    comboBoxSubtitlesYesNo.SelectedItem = "Yes";
                    string[] selectedSubtitles = preUpdatedMovie.SubtitlesLanguage.Split(',');
                    foreach (string subtitle in selectedSubtitles)
                    {
                        checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(subtitle.Trim()), true);
                    }
                }
                else
                {
                    comboBoxSubtitlesYesNo.SelectedItem = "No";
                }
            }
        }

        //open up ur file directionary so you can select a picture.
        //only works with images of type JPG or PNG
        private void btnChangePoster_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image(*.jpg; *.png;)|*.jpg; *.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog1.FileName; // Store the selected image file path
                pictureBox1.Image = Image.FromFile(selectedImagePath);
            }
        }

        //initializes the all comboxes
        private void InitializeComboBoxes()
        {
            //initialize combobox MPA Rating
            List<string> mpaRatings = new List<string> { "G", "PG", "PG-13", "R", "NC-17", "Not Rated" };
            comboBoxMpaRating.Items.AddRange(mpaRatings.ToArray());
            comboBoxMpaRating.DropDownStyle = ComboBoxStyle.DropDownList;

            //initialize combobox genre
            List<string> genres = new List<string> { "Action", "Comedy", "Drama", "Horror", "Sci-Fi", "Thriller" };
            comboBoxGenre.Items.AddRange(genres.ToArray());
            comboBoxGenre.DropDownStyle = ComboBoxStyle.DropDownList;

            //initialize combobox languages
            List<string> languages = new List<string> { "English", "Danish", "German", "Chinese", "French", "Spanish" };
            comboBoxLanguage.Items.AddRange(languages.ToArray());
            comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;

            //initialize combobox comboBox where you press yes or no to the movie havings subtitles
            comboBoxSubtitlesYesNo.Items.Add("Yes");
            comboBoxSubtitlesYesNo.Items.Add("No");
            comboBoxSubtitlesYesNo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //initialzes the checkbox containing subtitles languages
        private void IntializeCheckedListBox()
        {
            List<string> Subtitles = new List<string> { "English", "Danish", "German", "Chinese", "French", "Spanish" };
            checkedListBox1.Items.AddRange(Subtitles.ToArray());
            checkedListBox1.Enabled = false;
        }


        //if there is selected NO subtitles then you can no longer check the subtitles languages
        private void comboBoxSubtitlesYesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSubtitlesYesNo.SelectedItem.ToString() == "Yes")
            {
                checkedListBox1.Enabled = true;
            }
            else
            {
                checkedListBox1.Enabled = false;
                checkedListBox1.ClearSelected();
            }
        }

        //closes the window
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        // Submits the update of the movie if all the validations go through
        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (validateAll())
            {
                string title = txtTitle.Text;
                string genre = comboBoxGenre.Text;
                string actors = txtActors.Text;
                string director = txtDirector.Text;
                string language = comboBoxLanguage.Text;
                string releaseYear = dateTimePickerReleaseYear.Value.ToString("yyyy-MM-dd");
                byte subtitles = isThereSelectedSubtitles();
                string subtitlesLanguage = getAllSubtitlesLanguages();
                string mpaRatingEnum = comboBoxMpaRating.Text;
                int runtimeHours = Int32.Parse(textBoxRunTime.Text);
                string premierDate = dateTimePickerPremierDate.Value.ToString("yyyy-MM-dd");

                Poster updatedPoster;
                byte[] newImageData = null;

                // Check if a new image is selected
                if (selectedImagePath != null && !selectedImagePath.Equals(preUpdatedMovie.Poster.PosterTitle))
                {
                    string posterTitle = Path.GetFileNameWithoutExtension(selectedImagePath);
                    newImageData = File.ReadAllBytes(selectedImagePath);
                    updatedPoster = new Poster { PosterTitle = posterTitle, ImageData = newImageData };
                }
                else
                {
                    // Use the existing poster
                    updatedPoster = preUpdatedMovie.Poster;
                }

                // Update the movie
                Movie updatedMovie = new Movie(title, genre, actors, director, language, releaseYear, subtitles, subtitlesLanguage, mpaRatingEnum, runtimeHours, premierDate, updatedPoster);

                bool movieUpdated = await moviesManager.UpdateMovieByIdAsync(movieId, updatedMovie);

                if (movieUpdated)
                {
                    // Check if a new image is selected
                    if (newImageData != null)
                    {
                        MessageBox.Show("The movie and poster were updated.");
                        
                    }
                    else
                    {
                        MessageBox.Show("The movie was updated.");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Failed to update the movie.");
                }
                this.Close();
            }
        }

        // return 1 if there is selected yes to the movie having subtitles.
        // else returns 0.
        public byte isThereSelectedSubtitles()
        {
            byte subtitlesYesOrNo = 0;

            if (comboBoxSubtitlesYesNo.Text == "Yes")
            {
                subtitlesYesOrNo = 1;
            }

            return subtitlesYesOrNo;
        }

        //gets all subtitles languages.
        //if there is selected no subtitles. it returns a string saying there is none
        public string getAllSubtitlesLanguages()
        {
            string subtitlesLanguage = "";

            if (comboBoxSubtitlesYesNo.Text == "Yes")
            {

                // Retrieve selected subtitles languages from the CheckedListBox
                List<string> selectedSubtitles = new List<string>();
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    selectedSubtitles.Add(item.ToString());
                }
                subtitlesLanguage = string.Join(", ", selectedSubtitles);
            }
            else
            {
                subtitlesLanguage = "No Subtitles";
            }

            return subtitlesLanguage;
        }

        //Runs all the validations
        public bool validateAll()
        {
            bool wasOk = false;
            if (validateSubs() && validatePremierAndReleaseDate() && validateRuntime() && validateAllRequiredInputs())
            {
                wasOk = true;
            }

            return wasOk;
        }

        //Checks if movie subtitles language was not selected. if it was selected that the movie has subtitles.
        // also checks if subtitles language was selected. if it was selected that the movie does not have subtitles.
        public bool validateSubs()
        {
            bool wasOk = false;

            if (comboBoxSubtitlesYesNo.Text == "No" && checkedListBox1.CheckedItems.Count > 0)
            {
                MessageBox.Show("No subtitles was selected. Yet there was selected a subtitles language");
            }
            else if (comboBoxSubtitlesYesNo.Text == "Yes" && checkedListBox1.CheckedItems.Count < 1)
            {
                MessageBox.Show("Existence of subtitles was selected. Yet there was selected not ant subtitles languages");
            }
            else
            {
                wasOk = true;
            }

            return wasOk;

        }


        // checks if the Premier Date is selected to be before the Release Date.
        // The logic is that you can not show a movie for the first time(premier date), if it is not released yet.
        public bool validatePremierAndReleaseDate()
        {
            bool wasOk = true;

            if (dateTimePickerPremierDate.Value.Date < dateTimePickerReleaseYear.Value.Date)
            {
                MessageBox.Show("Premier Date is the first date the movie can be shown. We cannot show a movie before it is released.");

                wasOk = false;
            }

            return wasOk;
        }

        //checks if input in runtime contains anything else than whole numbers.
        public bool validateRuntime()
        {
            bool wasOk = true;
            int parsedValue;
            if (!int.TryParse(textBoxRunTime.Text, out parsedValue))
            {
                MessageBox.Show("Runtime is whole numbers only field.");
                wasOk = false;
            }
            return wasOk;
        }

        // checks if there is input in all the required fields to submit a movie
        public bool validateAllRequiredInputs()
        {
            bool wasOk = true;


            // Validate title
            string title = txtTitle.Text;
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a title.");
                wasOk = false;
            }

            // Validate genre
            string genre = comboBoxGenre.Text;
            if (string.IsNullOrEmpty(genre))
            {
                MessageBox.Show("Please select a genre.");
                wasOk = false;
            }

            // Validate actors
            string actors = txtActors.Text;
            if (string.IsNullOrEmpty(actors))
            {
                MessageBox.Show("Please enter actors.");
                wasOk = false;

            }

            // Validate director
            string director = txtDirector.Text;
            if (string.IsNullOrEmpty(director))
            {
                MessageBox.Show("Please enter a director.");
                wasOk = false;
            }

            // Validate language
            string language = comboBoxLanguage.Text;
            if (string.IsNullOrEmpty(language))
            {
                MessageBox.Show("Please select a language.");
                wasOk = false;
            }

            // Validate release year
            string releaseYear = dateTimePickerReleaseYear.Value.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(releaseYear))
            {
                MessageBox.Show("Please select a ReleaseDate.");
                wasOk = false;
            }

            // Validate Premier date
            string premierDate = dateTimePickerPremierDate.Value.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(premierDate))
            {
                MessageBox.Show("Please select a Premier date.");
                wasOk = false;
            }

            // Validate subtitlesYesOrNO
            string subtitlesYesOrNo = comboBoxSubtitlesYesNo.Text;
            if (string.IsNullOrEmpty(premierDate))
            {
                MessageBox.Show("Please select if the movie has subtitles");
                wasOk = false;
            }

            //Validate Runtime
            string runtime = textBoxRunTime.Text;
            if (string.IsNullOrEmpty(runtime))
            {
                MessageBox.Show("Please enter runtime info");
                wasOk = false;
            }

            //Validate MPA Rating
            string mpaRating = comboBoxMpaRating.Text;
            if (string.IsNullOrEmpty(mpaRating))
            {
                MessageBox.Show("Please select the movies MPA Rating");
                wasOk = false;
            }

            //validate Poster
            string poster = pictureBox1.ToString();
            if (string.IsNullOrEmpty(poster))
            {
                MessageBox.Show("Please select Picture");
                wasOk = false;
            }


            return wasOk;

        }



    }


}