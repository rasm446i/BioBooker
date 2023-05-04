using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views;

public partial class HomeView : Form
{
    public HomeView()
    {
        InitializeComponent();
    }

    private void BtnMoviesClick(object sender, System.EventArgs e)
    {
        MovieView movieView = new MovieView();
        movieView.Show();
    }

    private void BtnCloseClick(object sender, System.EventArgs e)
    {

    }

    private void buttonMovieTheater_Click(object sender, System.EventArgs e)
    {
        MovieTheaterView movieTheaterView = new MovieTheaterView();
        movieTheaterView.Show();
    }
}
