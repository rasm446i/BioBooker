using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BioBooker.Dml
{

    public class Auditorium
    {
        public int MovieTheaterId { get; set; }
        public int AuditoriumId { get; set; }
        public List<Seat> Seats { get; set; }
        public string Name { get; set; }

        public Auditorium()
        {
            
        }

        public Auditorium(List<Seat> seats, string name)
        {
            Seats = seats;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
