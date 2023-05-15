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
    public partial class CreateShowingView : Form
    {

        private int auditoriumId;
        public CreateShowingView(int auditoriumId)
        {
            InitializeComponent();
            this.auditoriumId = auditoriumId;
        }
    }
}
