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
    public partial class MovieTheaterView : Form
    {
        public MovieTheaterView()
        {
            InitializeComponent();
        }

        //string auditoriumName = lblAuditoriumName.Text;
        //string movieTheatername = lblMovieTheaterName.Text;
        private void buttonSeats_Click(object sender, EventArgs e)
        {
            List<Seat> seats = new List<Seat>();


                foreach (DataGridViewRow row in dataGridViewSeats.Rows)
                {
                    if (!row.IsNewRow)
                    {
                    Seat newSeat = new Seat()
                        {
                            SeatRow = Convert.ToInt32(row.Cells["SeatRow"].Value),
                            SeatNumber = Convert.ToInt32(row.Cells["SeatNumber"].Value),
                            IsAvailable = Convert.ToBoolean(row.Cells["IsAvailable"].Value),
                        };
                        seats.Add(newSeat);
                    }
                }

                // Do something with the list of seats, such as displaying them or saving them to a database.
            

        }


    }
}
