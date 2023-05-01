using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioBooker.WebApp.Uil.Controllers;

public class MovieController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }
}
