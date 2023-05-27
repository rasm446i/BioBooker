using BioBooker.WebApp.Uil.ViewModels;
using BioBooker.WebApp.Uil.ViewModels.Home;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BioBooker.WebApp.Uil.Controllers;

public class HomeController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View("Index");
    }

    public IActionResult Contact()
    {
        return View("Contact");
    }

    public async Task<IActionResult> About()
    {
        // Call API
        // Access the Tokens in a Current Session
        //var accessToken = await HttpContext.GetTokenAsync("access_token");

        // Access the API Using Access Token
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var content = await client.GetStringAsync("https://localhost:7011/identity");

        ViewBag.Json = JArray.Parse(content).ToString();
        return View("About");
    }

    public IActionResult Privacy()
    {
        return View("Privacy");
    }

    public IActionResult Logout()
    {
        return SignOut("Cookies", "oidc");
    }

    /// <summary>
    /// Redirects to the index action of the Movie controller to display the movies.
    /// </summary>
    /// <returns>A task representing the redirection to the Movie controller's index action.</returns>
    public IActionResult Movies()
    {
        return RedirectToAction("Index", "Movie");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
