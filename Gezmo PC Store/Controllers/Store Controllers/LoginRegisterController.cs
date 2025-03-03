using Gezmo_PC_Store.DataBaseModels;
using Gezmo_PC_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Gezmo_PC_Store.Services;
namespace Gezmo_PC_Store.Controllers.Store_Controllers;

public class LoginRegisterController:BaseController
{
    
    public LoginRegisterController(IGlobalsHelper globalsHelper, IDataProvider dataProvider) : base(globalsHelper,
        dataProvider)
    {
        
    }
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult ValidateInsertNewUser(RegisterUser user)
    {
        
        return RedirectToAction("Main", "Main");
    }
}