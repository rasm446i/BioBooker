using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{
    public class MovieTheater
    {
    public string Name { get; set; }

    public List<Auditorium> Auditoriums { get;set; }

    public MovieTheater(string name, Auditorium auditorium)
        {
            Auditoriums = new List<Auditorium>();
            Auditoriums.Add(auditorium);
        }


    }
}
