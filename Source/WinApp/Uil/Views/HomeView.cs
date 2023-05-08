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

    private void BtnMoviesClick(object sender, System.EventArgs e)
    {
        MovieView movieView = new MovieView(configuration);
        movieView.Show();
    }

    private void BtnCloseClick(object sender, System.EventArgs e)
    {

    }
}
