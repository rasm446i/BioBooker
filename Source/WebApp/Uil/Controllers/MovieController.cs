using BioBooker.Dml;
using BioBooker.WebApp.Bll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioBooker.WebApp.Uil.Controllers;

public class MovieController : Controller
{
    
    private readonly MovieManager _movieManager;

    public MovieController()
    {
        _movieManager = new MovieManager();
    }

    /// <summary>
    /// Displays the index view with a list of movies.
    /// </summary>
    /// <returns>A task representing the index view with a list of movies.</returns>
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        List<Movie> movies = await _movieManager.GetMovies();
        return View(movies);
    }

    /// <summary>
    /// Displays the showing view for a specific movie, including a list of showings.
    /// </summary>
    /// <param name="movieId">The ID of the movie.</param>
    /// <returns>A task representing the showing view with a list of showings.</returns>
    public async Task<IActionResult> ShowingView(int movieId)
    {
        List<Showing> showings = await _movieManager.GetShowingsByMovieIdAsync(movieId);

        if (showings == null)
        {
            showings = new List<Showing>();
        }

        return View(showings);
    }

}

