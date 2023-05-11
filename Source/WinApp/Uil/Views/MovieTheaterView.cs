using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class MovieTheaterView : Form
    {
        public MovieTheaterView()
        {
            InitializeComponent();
        }

        private void btnCreateMovieTheater_Click(object sender, EventArgs e)
        {
            CreateMovieTheaterView auditoriumView = new CreateMovieTheaterView();
            auditoriumView.Show();
        }

        private void btnCreateAuditoriums_Click(object sender, EventArgs e)
        {
            ShowAuditoriumsView auditoriumsView = new ShowAuditoriumsView();
            auditoriumsView.Show();
        }
    }
}
