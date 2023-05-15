using BioBooker.Dml;
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
    public partial class ShowingDetailView : Form
    {

        private int auditoriumId;
        public ShowingDetailView(int auditoriumId)
        {
            InitializeComponent();
            this.auditoriumId = auditoriumId;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
 
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
