using System.Diagnostics;
using System.Text.Json;
using Gezmo_PC_Store.Controllers.Store_Controllers;
using Microsoft.AspNetCore.Mvc;
using Gezmo_PC_Store.Models;
using Gezmo_PC_Store.Services;
namespace Gezmo_PC_Store.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(IGlobalsHelper globalsHelper, ILogger<HomeController> logger) : base(globalsHelper)
    {
        _logger = logger;
    }

    public  GlobalModels InitializeGlobals()
    {
       return new GlobalModels{LoggedIn = false}; 
    }
    public IActionResult Index()
    {
        GlobalModels Globals=InitializeGlobals();
        HttpContext.Session.SetString("Globals",JsonSerializer.Serialize(Globals));
        return RedirectToAction("Main","Main");
    }
 
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}