using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.Dml
{
    public class MovieTheater
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Auditorium> Auditoriums { get; set; }


        public MovieTheater()
        {

        }
        public MovieTheater(int id, string name)
        {
            Id = id;
            Name = name;    
        }
        public MovieTheater(string name, Auditorium auditorium)
        {
            Name = name;
            Auditoriums = new List<Auditorium>();
            if (auditorium != null)
            {
                Auditoriums.Add(auditorium);
            } else
            {
                throw new ArgumentNullException(nameof(auditorium), "An auditorium is required.");
            }
            

        }

        public override string ToString()
        {
            return Name;
        }


    }
}
