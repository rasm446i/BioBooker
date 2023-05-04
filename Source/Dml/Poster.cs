using System.Collections;
using System.Collections.Generic;

namespace BioBooker.Dml;

public class Poster
{
    public int Id { get; set; }
    public byte[] Version { get; set; }
    public string PosterTitle { get; set; }
    public byte[] ImageData { get; set; }

    
    public Poster(int id, byte[] version, string posterTitle, byte[] imageData)
    {
        Id = id;
        Version = version;
        PosterTitle = posterTitle;
        ImageData = imageData;
    }
}