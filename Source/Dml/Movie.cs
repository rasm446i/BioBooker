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

    public Movie(int id, string title, string genre, string actors, string director, string language, DateTime releaseYear, byte subtitles, string subtitlesLanguage, string mpaRatingEnum, int runtimeHours, int runtimeMinutes, DateTime premierDate)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Actors = actors;
        Director = director;
        Language = language;
        ReleaseYear = releaseYear;
        Subtitles = subtitles;
        SubtitlesLanguage = subtitlesLanguage;
        MPARatingEnum = mpaRatingEnum;
        RuntimeHours = runtimeHours;
        RuntimeMinutes = runtimeMinutes;
        PremierDate = premierDate;

    }

    public enum MPARating
    {
        G,
        PG,
        PG13,
        R,
        NC17,
        NotRated
    }

    public enum Genres
    {
        Action,
        Comedy,
        Drama,
        Horror,
        SciFi,
        Thriller
    }

    public enum Subtitle
    {
        English,
        Spanish,
        French,
        German,
        Chinese,
        Danish
    }

    public int Id { get; set; }
    //public byte[] Version { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Actors { get; set; }
    public string Director { get; set; }
    public string Language { get; set; }
    public DateTime ReleaseYear { get; set; }
    public Byte Subtitles { get; set; }
    public string SubtitlesLanguage { get; set; }
    public string MPARatingEnum { get; set; }
    public int RuntimeHours { get; set; }
    public int RuntimeMinutes { get; set; }
    public DateTime PremierDate { get; set; }
   
}




