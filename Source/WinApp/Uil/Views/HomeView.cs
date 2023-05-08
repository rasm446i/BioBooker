using Microsoft.Extensions.Configuration;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views;

public partial class HomeView : Form
{

    private readonly IConfiguration configuration;
    public HomeView(IConfiguration configuration)
    {
        InitializeComponent();
        this.configuration = configuration;
    }



    private void BtnCloseClick(object sender, System.EventArgs e)
    {

    }

    private void buttonViewMovies_Click(object sender, System.EventArgs e)
    {
        ViewMoviesView viewMovies = new ViewMoviesView(configuration);
        viewMovies.Show();
    }

    private void btnCreateMovies_Click(object sender, System.EventArgs e)
    {
        CreateMovieView createMovie = new CreateMovieView(configuration);
        createMovie.Show();
    }
}
