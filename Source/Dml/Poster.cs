using System.Collections;
using System.Collections.Generic;

namespace BioBooker.Dml;

public class Poster
{
    //public byte[] Version { get; set; }
    public int MovieId { get; set; }
    public string PosterTitle { get; set; }
    public byte[] ImageData { get; set; }


    public Poster()
    {
        
    }

    public Poster(string posterTitle, byte[] imageData)
    {
        PosterTitle = posterTitle;
        ImageData = imageData;
    }
}