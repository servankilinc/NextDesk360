using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressDesk360.WebUI.Controllers;

public class HomeController : Controller
{
    /// <summary>Landing page for signed-in users. Covered by the global fallback policy.</summary>
    [HttpGet]
    public IActionResult Index() => View();

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Privacy() => View();
}
