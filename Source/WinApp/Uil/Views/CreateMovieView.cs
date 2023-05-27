using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views;

//constructor
public partial class CreateMovieView : Form
{

    private string? selectedImagePath;
    private IMoviesManager moviesManager;

    public CreateMovieView(IConfiguration configuration)
    {
        moviesManager = new MoviesManager(configuration);
        InitializeComponent();
        InitializeComboBoxes();
        IntializeCheckedListBox();
    }


    /// <summary>
    /// Event handler for the "Add Poster" button click event.
    /// Allows the user to select an image file (in .jpg or .png format) and displays it in a PictureBox control.
    /// </summary>
    /// <param name="sender">The object that raises the event.</param>
    /// <param name="e">The event data.</param>
    private void btnAddPoster_Click(object sender, EventArgs e)
    {
        openFileDialog1.Filter = "Select image(*.jpg; *.png;)|*.jpg; *.png;";
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            selectedImagePath = openFileDialog1.FileName; // Store the selected image file path
            pictureBox1.Image = Image.FromFile(selectedImagePath);
        }
    }

    /// <summary>
    /// Initializes the ComboBox controls for MPA Rating, genre, languages, and subtitles options.
    /// </summary>
    private void InitializeComboBoxes()
    {
        // Initialize combobox MPA Rating
        List<string> mpaRatings = new List<string> { "G", "PG", "PG-13", "R", "NC-17", "Not Rated" };
        comboBoxMpaRating.Items.AddRange(mpaRatings.ToArray());
        comboBoxMpaRating.DropDownStyle = ComboBoxStyle.DropDownList;

        // Initialize combobox genre
        List<string> genres = new List<string> { "Action", "Comedy", "Drama", "Horror", "Sci-Fi", "Thriller" };
        comboBoxGenre.Items.AddRange(genres.ToArray());
        comboBoxGenre.DropDownStyle = ComboBoxStyle.DropDownList;

        // Initialize combobox languages
        List<string> languages = new List<string> { "English", "Danish", "German", "Chinese", "French", "Spanish" };
        comboBoxLanguage.Items.AddRange(languages.ToArray());
        comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;

        // Initialize combobox comboBox where you press yes or no to the movie havings subtitles
        comboBoxSubtitlesYesNo.Items.Add("Yes");
        comboBoxSubtitlesYesNo.Items.Add("No");
        comboBoxSubtitlesYesNo.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    /// <summary>
    /// Initializes the CheckedListBox control for selecting subtitles options.
    /// </summary>
    private void IntializeCheckedListBox()
    {
        List<string> Subtitles = new List<string> { "English", "Danish", "German", "Chinese", "French", "Spanish" };
        checkedListBox1.Items.AddRange(Subtitles.ToArray());
        checkedListBox1.Enabled = false;
    }


    /// <summary>
    /// Event handler for the SelectedIndexChanged event of the comboBoxSubtitlesYesNo control.
    /// Enables or disables the checkedListBox1 control based on the selected value.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An EventArgs that contains the event data.</param>
    private void comboBoxSubtitlesYesNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxSubtitlesYesNo.SelectedItem.ToString() == "Yes")
        {
            checkedListBox1.Enabled = true;
        }
        else

        {
            checkedListBox1.Enabled = false;
            for(int i = 0; i < checkedListBox1.Items.Count; i++) // If subtitles is no, uncheck all items in listbox
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            
        }
    }

    /// <summary>
    /// Closes the window
    /// </summary>
    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();

    }

    /// <summary>
    /// Event handler for the buttonSubmit click event. Submits a new movie by retrieving data from input fields, creating movie and poster objects, and inserting them into the database.
    /// </summary>
    /// <param name="sender">The sender object.</param>
    /// <param name="e">The event arguments.</param>
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
            string mpaRatingEnum = comboBoxMpaRating.Text;
            int runtimeHours = Int32.Parse(textBoxRunTime.Text);
            Image image = pictureBox1.Image;
            string posterTitle = Path.GetFileNameWithoutExtension(selectedImagePath);
            byte[] imageData = File.ReadAllBytes(selectedImagePath);
            string subtitlesLanguage = getAllSubtitlesLanguages();
            byte subtitles = isThereSelectedSubtitles();

            Poster poster = new Poster(posterTitle, imageData);

            Movie movie = new Movie(title, genre, actors, director, language, releaseYear, subtitles, subtitlesLanguage, mpaRatingEnum, runtimeHours, poster);

            bool inserted = await moviesManager.CreateAndInsertMovieAsync(movie, poster);
            if(inserted)
            {
                MessageBox.Show("The movie was submitted.");
            } 
            else
            {
                MessageBox.Show("The movie was not submitted, make sure the fields are filled correctly.");
            }
            this.Close();
        }
    }



    /// <summary>
    /// Checks whether subtitles are selected or not and returns a byte value indicating the presence of subtitles.
    /// </summary>
    /// <returns>A byte value representing the presence of subtitles. 1 indicates subtitles are selected, 0 indicates no subtitles.</returns>
    public byte isThereSelectedSubtitles()
    {
        byte subtitlesYesOrNo = 0;

        if (comboBoxSubtitlesYesNo.Text == "Yes")
        {
            subtitlesYesOrNo = 1;
        }

            return subtitlesYesOrNo;
    }

    /// <summary>
    /// Retrieves the selected subtitles languages from the CheckedListBox and returns them as a concatenated string.
    /// If subtitles are not selected, returns "No Subtitles".
    /// </summary>
    /// <returns>A string representing the selected subtitles languages, separated by commas. If no subtitles are selected, returns "No Subtitles".</returns>
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
            subtitlesLanguage = string.Join(", ", selectedSubtitles); // Concatenate the selected subtitles languages with a comma separator
        }
        else
        {
            subtitlesLanguage = "No Subtitles";
        }

        return subtitlesLanguage;
    }

    /// <summary>
    /// Runs all the validations
    /// </summary>
    public bool validateAll()
    {
        bool wasOk = false;
        if (validateSubs() && validateRuntime()&& validateAllRequiredInputs())
        {
            wasOk = true;
        }

        return wasOk;
    }

    /// <summary>
    /// Validates the selection of subtitles based on the chosen option and checked items.
    /// </summary>
    /// <returns>True if the selection is valid; otherwise, false.</returns>
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


    /// <summary>
    /// Checks if input in runtime contains anything else than whole numbers.
    /// </summary>
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

    /// <summary>
    /// Validates all the required inputs for creating a movie.
    /// </summary>
    /// <returns>True if all inputs are valid; otherwise, false.</returns>
    public bool validateAllRequiredInputs()
    {
        bool wasOk = true;


        // Validate title
        string title = txtTitle.Text;
        if (string.IsNullOrEmpty(title))
        {
            MessageBox.Show("Please enter a title.");
            wasOk= false;
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

    /// <summary>
    /// Returns the image path of the poster
    /// </summary>
    public string GetSelectedImagePath()
    {
        return selectedImagePath;
    }
}


