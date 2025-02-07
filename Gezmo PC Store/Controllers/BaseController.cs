using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Gezmo_PC_Store.Services;
namespace Gezmo_PC_Store.Controllers;

public class BaseController:Controller
{
    private readonly IGlobalsHelper _globalsHelper;

    public BaseController(IGlobalsHelper globalsHelper)
    {
        _globalsHelper = globalsHelper;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        ViewData["Globals"] = _globalsHelper.FetchGlobals(HttpContext);
    }
}