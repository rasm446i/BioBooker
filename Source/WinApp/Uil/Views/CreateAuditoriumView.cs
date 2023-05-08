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

            if (amountOfRowsParseResult <= 0 || seatsPerRowParseResult <= 0 && !String.IsNullOrEmpty(movieTheaterName))
            {
                MessageBox.Show("Amount of rows and seats per row must be higher than 0");
            }
            else
            {

                List<Seat> seats = new List<Seat>();
                for(int i = 0; i < amountOfRowsParseResult; i++)
                {
                    for (int j = 0; j < seatsPerRowParseResult; j++)
                    {
                        seats.Add(new Seat(i, j));
                    }
                }
                await movieTheaterController.PassListOfSeatsToAuditoriumCreateAuditorium(movieTheaterName, seats);
                
       //         Seat[,] seats = new Seat[amountOfRows, seatsPerRow];
       //         for (int rowNumber = 0; rowNumber < amountOfRows; rowNumber++)
       //         {
       //             for (int seatNumber = 0; seatNumber < seatsPerRow; seatNumber++)
       //             {
       //                 seats[rowNumber, seatNumber] = new Seat(seatNumber + 1, rowNumber + 1);
       //             }
       //             }
            }
        }
    }
}
