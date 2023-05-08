using System;
using System.IO;
using System.Drawing;
using BioBooker.Dml;
using System.Collections;
using System.Collections.Generic;


namespace BioBooker.Dml;

public class Movie
{

    public Movie()
    {

    }

    public Movie(string title, string genre, string actors, string director, string language, string releaseYear, byte subtitles, string subtitlesLanguage, string mpaRatingEnum, int runtimeMinutes, string premierDate, Poster poster)
    {
        Title = title;
        Genre = genre;
        Actors = actors;
        Director = director;
        Language = language;
        ReleaseYear = releaseYear;
        Subtitles = subtitles;
        SubtitlesLanguage = subtitlesLanguage;
        MPARatingEnum = mpaRatingEnum;
        RuntimeMinutes = runtimeMinutes;
        PremierDate = premierDate;
        Poster = poster;
    }


    public int Id { get; set; }
    //public byte[] Version { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Actors { get; set; }
    public string Director { get; set; }
    public string Language { get; set; }

    public string ReleaseYear { get; set; }
    public Byte Subtitles { get; set; }
    public string SubtitlesLanguage { get; set; }
    public string MPARatingEnum { get; set; }
    public int RuntimeMinutes { get; set; }
    public string PremierDate { get; set; }
    public Poster Poster { get; set; }
    
}




