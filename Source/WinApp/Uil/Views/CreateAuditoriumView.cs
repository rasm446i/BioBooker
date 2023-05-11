using BioBooker.Dml;
using BioBooker.WinApp.Uil.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil.Views
{
    public partial class CreateAuditoriumView : Form
    {
        MovieTheaterController movieTheaterController;
        public CreateAuditoriumView()
        {
            InitializeComponent();
            movieTheaterController = new MovieTheaterController();
        }

        private async void btnCreateAuditorium_Click(object sender, EventArgs e)
        {
            string movieTheaterName = txtBoxMovieTheaterName.Text;
            string amountOfRows = txtBoxAmountOfRows.Text;
            string seatsPerRow = txtBoxSeatsPerRow.Text;

            int amountOfRowsParseResult = int.Parse(amountOfRows);
            int seatsPerRowParseResult = int.Parse(seatsPerRow);

            if ((amountOfRowsParseResult < 1 || seatsPerRowParseResult < 1))
            {
                MessageBox.Show("Amount of rows and seats per row must be higher than 0");
            }
            else if (String.IsNullOrEmpty(movieTheaterName) || !ContainsOnlyLetters(movieTheaterName)) 
            {
            MessageBox.Show("Movie theater name can't be empty and must only contain letters");
            }
            else
            {
                await movieTheaterController.CreateSeatsAndMovieTheaterFromUserInput(movieTheaterName, amountOfRowsParseResult, seatsPerRowParseResult);  
            }
        }

        private bool ContainsOnlyLetters(string movieTheaterName)
        {
            foreach (char letter in movieTheaterName)
            {
                if(!char.IsLetter(letter))
                {        
                    return false;
                }
            }
            return true;
        }
    }
}
