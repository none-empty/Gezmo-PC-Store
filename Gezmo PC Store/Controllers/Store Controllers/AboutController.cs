using Gezmo_PC_Store.Services;
using Microsoft.AspNetCore.Mvc;
using Gezmo_PC_Store.Services; 
    
namespace Gezmo_PC_Store.Controllers.Store_Controllers;
public class AboutController:BaseController
{
    public AboutController(IGlobalsHelper globalsHelper) : base(globalsHelper) { }
   public  IActionResult About()
    {
      return View();
    }
   
}