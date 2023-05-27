using BioBooker.Dml;
using BioBooker.WinApp.Bll;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;
using static Dapper.SqlMapper;

namespace BioBooker.WinApp.IntegrationTests.Bll
{
    public class MovieTheaterBusinessControllerTests
    {
<<<<<<< HEAD
        private readonly string _connectionString = "server=localhost; Database=BioBooker; integrated security=true;";
        private readonly string _sqlScript = @"USE master;

DROP DATABASE IF EXISTS BioBooker;


        CREATE DATABASE BioBooker;

        USE BioBooker;

CREATE TABLE MovieTheaters(
  Id INT IDENTITY(1, 1),
  [Name] VARCHAR(30) NOT NULL,
  CONSTRAINT[PK_MovieTheaterId] PRIMARY KEY(Id),
  CONSTRAINT[UQ_Name] UNIQUE([Name])
);

        CREATE TABLE Auditorium(
  AuditoriumId INT IDENTITY(1, 1),
  MovieTheaterId INT REFERENCES MovieTheaters(Id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  [Name] VARCHAR(30),
  CONSTRAINT[PK_AuditoriumId] PRIMARY KEY(AuditoriumId),
  CONSTRAINT[UQ_Name_MovieTheaterId] UNIQUE([Name], MovieTheaterId)
);

        CREATE TABLE Seats(
        IsAvailable BIT,
        SeatRow INT,
        SeatNumber INT,
        AuditoriumId INT,
  CONSTRAINT[CompositeKey_Seat] PRIMARY KEY (SeatRow, SeatNumber, AuditoriumId),
  CONSTRAINT[FK_AuditoriumId] FOREIGN KEY(AuditoriumId) REFERENCES Auditorium(AuditoriumId)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);
     

        CREATE TABLE Movies(
          Id INT IDENTITY(1, 1) PRIMARY KEY,
          Title NVARCHAR(255) NOT NULL,
          Genre NVARCHAR(255) NOT NULL,
          Actors NVARCHAR(255) NOT NULL,
          Director NVARCHAR(255) NOT NULL,
        
          [Language] NVARCHAR(255) NOT NULL,
        ReleaseYear DATE NOT NULL,
  Subtitles BIT NOT NULL,
  SubtitlesLanguage NVARCHAR(255) NOT NULL,
  MPARating NVARCHAR(255) NOT NULL,
  RuntimeMinutes INT NOT NULL,
  PremierDate DATE NOT NULL
);

        CREATE TABLE Posters(
          MovieId INT PRIMARY KEY FOREIGN KEY REFERENCES Movies(Id) ON DELETE CASCADE,
          PosterTitle NVARCHAR(255) NOT NULL,
          ImageData VARBINARY(MAX) NOT NULL
);";
        private MovieTheaterManager _movieTheaterBusinessController;
=======
        private readonly string _connectionString = "server=.\\SQLExpress; Database=BioBooker; integrated security=true;";
        private readonly string _sqlScript = @"DELETE FROM MovieTheaters WHERE Name = 'MovieTheater'";
        private MovieTheaterBusinessController _movieTheaterBusinessController;
>>>>>>> AddShowingsGUI

        public MovieTheaterBusinessControllerTests()
        {
            _movieTheaterBusinessController = new MovieTheaterManager();
        }

        [Fact]
        public async Task CreateMovieTheaterAndInsertAsync_ReturnsTrue_WhenMovieTheaterHasBeenInserted()
        {
<<<<<<< HEAD
            ResetDatabase();
            
=======

            ResetDatabase();
>>>>>>> AddShowingsGUI
            //arrange
            string movieTheaterName = "MovieTheater";
            string auditoriumName = "Auditorium 1";
            List<Seat> seats = new List<Seat>
            {
            new Seat(1, 1),
            new Seat(1, 2),
            new Seat(2, 1),
            new Seat(2, 2)
            };

            //act
            bool result = await _movieTheaterBusinessController.CreateMovieTheaterAndInsertAsync(movieTheaterName, seats, auditoriumName);

            //assert
            Assert.True(result);

            ResetDatabase();
        }

        private void ResetDatabase()
        {
            {
<<<<<<< HEAD
            new Seat(1, 1),
            new Seat(1, 2),
            new Seat(2, 1),
            new Seat(2, 2)
            };
            Auditorium newAuditorium = _movieTheaterBusinessController.CreateAuditorium(seats, auditoriumName);

            //act
            bool result = await _movieTheaterBusinessController.AddAuditoriumToMovieTheaterAsync(movieTheaterId, newAuditorium);

            //assert
            Assert.True(result);

        }

        public void ResetDatabase()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(_sqlScript);
=======
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    connection.Execute(_sqlScript);
                    connection.Close();
                }
>>>>>>> AddShowingsGUI
            }

        }
    }
}
