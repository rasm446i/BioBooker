using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    public IActionResult About()
    {
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
}
