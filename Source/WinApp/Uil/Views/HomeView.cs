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

    /// <summary>
    /// Event handler for the Click event of the buttonViewMovies button.
    /// Also opens the ViewMoviesView form to display a view of existing movies.
    /// </summary>
    private void buttonViewMovies_Click(object sender, System.EventArgs e)
    {
        ViewMoviesView viewMovies = new ViewMoviesView(configuration);
        viewMovies.Show();
    }

    /// <summary>
    /// Event handler for the Click event of the btnCreateMovies button.
    /// Also opens the CreateMovieView form to create a new movie.
    /// </summary>
    private void btnCreateMovies_Click(object sender, System.EventArgs e)
    {
        CreateMovieView createMovie = new CreateMovieView(configuration);
        createMovie.Show();
    }

    /// <summary>
    /// Event handler for the Click event of the buttonMovieTheater button.
    /// Also opens the MovieTheaterView form to manage movie theaters.
    /// </summary>
    private void buttonMovieTheater_Click(object sender, System.EventArgs e)
    {
        MovieTheaterView movieTheaterView = new MovieTheaterView();
        movieTheaterView.Show();
    }

    /// <summary>
    /// Closes the window
    /// </summary>
    private void btnClose_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }
}

