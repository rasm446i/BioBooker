using Microsoft.AspNetCore.Mvc;

namespace BioBooker.WebApp.Uil.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("Index");
    }
}
