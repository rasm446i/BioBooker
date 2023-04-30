using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
}
