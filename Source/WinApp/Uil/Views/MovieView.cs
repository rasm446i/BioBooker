using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views;

public partial class MovieView : Form
{

    private string? selectedImagePath;
    private MoviesManager moviesManager;
    private string hexImageData;
    public MovieView(IConfiguration configuration)
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


    // USED TO SHOW THE POSTERS IN THE DATABASE
    /*
    private async void buttonShow_Click(object sender, EventArgs e)
    {
        string title =  txtTitle.Text;
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
    }*/

}


