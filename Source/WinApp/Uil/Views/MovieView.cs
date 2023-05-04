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
        if(openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }
    }
}
