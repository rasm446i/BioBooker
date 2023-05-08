using System.Collections;
using System.Collections.Generic;

namespace BioBooker.Dml;

public class Poster
{
    //public byte[] Version { get; set; }
    public int MovieId { get; set; }
    public string PosterTitle { get; set; }
    public string ImageData { get; set; }


    public Poster()
    {
        
    }

    public Poster(string posterTitle, string imageData)
    {
        PosterTitle = posterTitle;
        ImageData = imageData;
    }
}