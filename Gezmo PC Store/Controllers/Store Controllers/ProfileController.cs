using Gezmo_PC_Store.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gezmo_PC_Store.Controllers.Store_Controllers;

public class ProfileController:BaseController
{
    public ProfileController(IGlobalsHelper globalsHelper, IDataProvider dataProvider) : base(globalsHelper, dataProvider)
    {
    }
    public IActionResult Profile()
    {
        return View();
    }
}