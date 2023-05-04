using System;
using System.IO;
using System.Drawing;
using BioBooker.Dml;
using System.Collections;
using System.Collections.Generic;

namespace BioBooker.Dml;

public class Movie
{


    public Movie(string title, string genre, string actors, string director, string language, DateTime releaseYear, bool subtitles, string subtitlesLanguage, MPARating? mpaRating, int runtimeHours, int runtimeMinutes, string dimension, DateTime premierDate, Poster poster)
    {
        Title = title;
        Genre = genre;
        Actors = actors;
        Director = director;
        Language = language;
        ReleaseYear = releaseYear;
        Subtitles = subtitles;
        SubtitlesLanguage = subtitlesLanguage;
        MPARatingEnum = mpaRating;
        RuntimeHours = runtimeHours;
        RuntimeMinutes = runtimeMinutes;
        Dimension = dimension;
        PremierDate = premierDate;
        Poster = poster;
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

    public int Id { get; set; }
    public Byte[] Version { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Actors { get; set; }
    public string Director { get; set; }
    public string Language { get; set; }
    public DateTime ReleaseYear { get; set; }
    public bool Subtitles { get; set; }
    public string SubtitlesLanguage { get; set; }
    public MPARating? MPARatingEnum { get; set; }
    public string Summary { get; set; }
    public int RuntimeHours { get; set; }
    public int RuntimeMinutes { get; set; }
    public Poster Poster { get; set; }
    public string Dimension { get; set; }
    public DateTime PremierDate { get; set; }


    /// <summary>
    /// Gets or sets the IMDb rating of the movie.
    /// </summary>
    /// <value>
    /// The IMDb rating of the movie. Must be a number between 0 and 10, with a maximum of two decimal places.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the input value is not a valid number, is greater than 10 or less than 0, or has more than two decimal places.</exception>
    /*public double IMDbRating
    {
        get { return _imdbRating; }
        set
        {
            double rating;
            if (double.TryParse(value.ToString(), out rating))
            {
                if (rating >= 0 && rating <= 10)
                {
                    if (rating.ToString().Length > 3)
                    {
                        throw new ArgumentOutOfRangeException("max 2 decimals");
                    }
                    _imdbRating = Math.Round(rating, 2);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Number must be greater than 0 or maximum 10");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("must only contain numbers and decimal point");
            }
        }*/
    
    }



    