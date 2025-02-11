using System.Text.Json;
using Gezmo_PC_Store.DataBaseModels;
using Gezmo_PC_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Gezmo_PC_Store.Services;
namespace Gezmo_PC_Store.Controllers.Store_Controllers;

public class MainController:BaseController
{
    public MainController(IGlobalsHelper globalsHelper,IDataProvider dataProvider) : base(globalsHelper,dataProvider) { }
    public IActionResult Main()
    {
          
        return View(new MainModel());
    }
}