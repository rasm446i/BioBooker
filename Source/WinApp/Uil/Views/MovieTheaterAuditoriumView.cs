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
    public partial class MovieTheaterAuditoriumView : Form
    {
        public MovieTheaterAuditoriumView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1) 
            {
                errorLabel.Text = "Select a value with the dropdown below";
            }
            else
            {
                var selectedItem = comboBox1.SelectedIndex;
                GetAuditoriumById(int id);

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }




        private void InsertAuditoriumIntoView(Auditorium auditorium)
        {

        }



    }
}
