using BioBooker.Dml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views;

public partial class MovieView : Form
{
    public MovieView()
    {
        InitializeComponent();
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

    private void btnAddPoster_Click(object sender, System.EventArgs e)
    {
        openFileDialog1.Filter = "Select image(*.jpg; *.png;)|*.jpg; *.png;";
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }
    }

    private void checkedListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {

    }

    private void comboBoxMpaRating_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        List<string> mpaRatings = new List<string> { "G", "PG", "PG-13", "R", "NC-17", "Not Rated" };
        comboBoxMpaRating.Items.AddRange(mpaRatings.ToArray());
    }

    private void comboBoxGenre_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<string> genres = new List<string> { "Action", "Comedy", "Drama", "Horror", "Sci-Fi", "Thriller" };
        comboBoxGenre.Items.AddRange(genres.ToArray());
    }
}
