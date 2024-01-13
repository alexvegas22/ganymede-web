using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ganymede_web.Models;

namespace ganymede_web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISession session;

    public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
    {
        this.session = httpContextAccessor.HttpContext.Session;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
	public IActionResult Dons()
	{
		return View();
	}

    public IActionResult Logout() 
    {
        session.Remove("id");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
