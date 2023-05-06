using System.Collections;
using System.Collections.Generic;

namespace BioBooker.Dml;

public class Poster
{
    public int Id { get; set; }
    //public byte[] Version { get; set; }
    public int MovieId { get; set; }
    public string PosterTitle { get; set; }
    public string ImageData { get; set; }


    public Poster()
    {
        
    }

    public Poster(int id, int movieId, string posterTitle, string imageData)
    {
        Id = id;
        MovieId = movieId;
        PosterTitle = posterTitle;
        ImageData = imageData;
    }
}