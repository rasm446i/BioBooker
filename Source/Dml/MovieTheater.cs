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

        public List<Auditorium> Auditoriums { get; set; } = new List<Auditorium>();


        public MovieTheater()
        {

        }
        public MovieTheater(int id, string name)
        {
            Id = id;
            Name = name;    
        }
        //temp constructor
        public MovieTheater(string name) 
        { 
            Name = name;
        }
        public MovieTheater(string name, Auditorium auditorium)
        {
            Name = name;
            if(auditorium != null)
            {
                Auditoriums.Add(auditorium);
            }
            throw new ArgumentNullException(nameof(auditorium), "An auditorium is required.");
        }


    }
}
