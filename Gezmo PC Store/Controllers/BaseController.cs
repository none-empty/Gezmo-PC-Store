using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Gezmo_PC_Store.Services;
namespace Gezmo_PC_Store.Controllers;

public class BaseController:Controller
{
    private readonly IGlobalsHelper _globalsHelper;
    protected readonly IDataProvider _dataProvider;
    protected const int PAGESIZE = 50;
    public BaseController(IGlobalsHelper globalsHelper, IDataProvider dataProvider)
    {
        _globalsHelper = globalsHelper;
        _dataProvider = dataProvider;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        ViewData["Globals"] = _globalsHelper.FetchGlobals(HttpContext);
    }
}