using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views;

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
        InitializeSubtitleDropDown();
    }


    private void label1_Click(object sender, System.EventArgs e)
    {

    }

    private void BtnCloseClick(object sender, System.EventArgs e)
    {

    }

    private void lblReleaseYear_Click(object sender, System.EventArgs e)
    {

    }

    private void BtnAddPosterClick(object sender, System.EventArgs e)
    {

    }

    private void txtGenre_TextChanged(object sender, System.EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, System.EventArgs e)
    {

    }

    private void lblReleaseYear_Click_1(object sender, System.EventArgs e)
    {

    }

    private void pnlInputs_Paint(object sender, PaintEventArgs e)
    {

    }

    private void label3_Click(object sender, System.EventArgs e)
    {

    }

    private void btnAddPoster_Click(object sender, EventArgs e)
    {
        openFileDialog1.Filter = "Select image(*.jpg; *.png;)|*.jpg; *.png;";
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            selectedImagePath = openFileDialog1.FileName; // Store the selected image file path
            pictureBox1.Image = Image.FromFile(selectedImagePath);
        }
    }

    private void InitializeSubtitleDropDown()
    {
        comboBoxSubtitlesYesNo.Items.Add("Yes");
        comboBoxSubtitlesYesNo.Items.Add("No");
        comboBoxSubtitlesYesNo.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    private void InitializeComboBoxes()
    {
        List<string> mpaRatings = new List<string> { "G", "PG", "PG-13", "R", "NC-17", "Not Rated" };
        comboBoxMpaRating.Items.AddRange(mpaRatings.ToArray());
        comboBoxMpaRating.DropDownStyle = ComboBoxStyle.DropDownList;

        List<string> genres = new List<string> { "Action", "Comedy", "Drama", "Horror", "Sci-Fi", "Thriller" };
        comboBoxGenre.Items.AddRange(genres.ToArray());
        comboBoxGenre.DropDownStyle = ComboBoxStyle.DropDownList;

        List<string> languages = new List<string> { "English", "Danish", "German", "Chinese", "French", "Spanish" };
        comboBoxLanguage.Items.AddRange(languages.ToArray());
        comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    private void IntializeCheckedListBox()
    {
        List<string> Subtitles = new List<string> { "English", "Danish", "German", "Chinese", "French", "Spanish" };
        checkedListBox1.Items.AddRange(Subtitles.ToArray());
        checkedListBox1.Enabled = false;
    }



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

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();

    }

    private async void buttonSubmit_Click(object sender, EventArgs e)
    {
        string title = txtTitle.Text;
        string genre = comboBoxGenre.Text;
        string actors = txtActors.Text;
        string director = txtDirector.Text;
        string language = comboBoxLanguage.Text;
        string releaseYear = dateTimePickerReleaseYear.Value.ToString("yyyy-MM-dd");

        byte subtitles = 0;
        string subtitlesLanguage = "";
        if (comboBoxSubtitlesYesNo.Text == "Yes")
        {
            subtitles = 1;

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

        string mpaRatingEnum = comboBoxMpaRating.Text;

        int runtimeHours = 0;
        int parsedRuntimeHours;
        if (int.TryParse(textBoxRunTime.Text, out parsedRuntimeHours))
        {
            runtimeHours = parsedRuntimeHours;
        }
        else
        {
            MessageBox.Show("Invalid runtime hours. Please enter a valid integer.");
        }

        string premierDate = dateTimePickerPremierDate.Value.ToString("yyyy-MM-dd");
        Image image = pictureBox1.Image;
        string posterTitle = Path.GetFileNameWithoutExtension(selectedImagePath);
        byte[] imageData = File.ReadAllBytes(selectedImagePath);

        Poster poster = new Poster(posterTitle, imageData);
        
        Movie movie = new Movie(title, genre, actors, director, language, releaseYear, subtitles, subtitlesLanguage, mpaRatingEnum, runtimeHours, premierDate, poster);

        bool inserted = await moviesManager.CreateAndInsertMovieAsync(movie, poster);
    }

    public bool validateAll()
    {
        bool wasOk = false;
        if (validateSubs() && validatePremierAndReleaseDate() && validateRuntime())
        {
            wasOk = true;
        }



        return wasOk;
    }

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

    public bool validatePremierAndReleaseDate()
    {
        bool wasOk = true;

        if (dateTimePickerPremierDate.Value < dateTimePickerReleaseYear.Value)
        {
            MessageBox.Show("Premier Date is the first date the movie i shown. We cannot show a movie before it is released.");

            wasOk = false;
        }

        return wasOk;

    }
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

    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }


    

}


