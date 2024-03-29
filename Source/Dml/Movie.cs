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

    // Constructor also has version
    public Movie(string title, string genre, string actors, string director, string language, string releaseYear, byte subtitles, string subtitlesLanguage, string mpaRating, int runtimeMinutes, Poster poster, byte[] version)
    {
        Version = version;
        Title = title;
        Genre = genre;
        Actors = actors;
        Director = director;
        Language = language;
        ReleaseYear = releaseYear;
        Subtitles = subtitles;
        SubtitlesLanguage = subtitlesLanguage;
        MPARating = mpaRating;
        RuntimeMinutes = runtimeMinutes;
        Poster = poster;
    }

    public Movie(string title, string genre, string actors, string director, string language, string releaseYear, byte subtitles, string subtitlesLanguage, string mpaRatingEnum, int runtimeMinutes, Poster poster)
    {
        Title = title;
        Genre = genre;
        Actors = actors;
        Director = director;
        Language = language;
        ReleaseYear = releaseYear;
        Subtitles = subtitles;
        SubtitlesLanguage = subtitlesLanguage;
        MPARating = mpaRatingEnum;
        RuntimeMinutes = runtimeMinutes;
        Poster = poster;
    }


    public int Id { get; set; }
    public byte[]? Version { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Actors { get; set; }
    public string Director { get; set; }
    public string Language { get; set; }

    public string ReleaseYear { get; set; }
    public Byte Subtitles { get; set; }
    public string SubtitlesLanguage { get; set; }
    public string MPARating { get; set; }
    public int RuntimeMinutes { get; set; }
    public Poster Poster { get; set; }
    
}




