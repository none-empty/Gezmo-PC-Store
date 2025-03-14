using Gezmo_PC_Store.Models;
using Gezmo_PC_Store.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gezmo_PC_Store.Controllers.Store_Controllers;

public class RecentOrdersController:BaseController
{
    private readonly IOrdersHandler _ordersHandler;
    public RecentOrdersController(IGlobalsHelper globalsHelper, IDataProvider dataProvider,IOrdersHandler ordersHandler) : base(globalsHelper, dataProvider)
    {
        _ordersHandler = ordersHandler;
    }

    public async Task<IActionResult> RecentOrders()
    {
        var userid = _globalsHelper
            .FetchGlobals(HttpContext)
            .User!
            .UserId;
        var model = new RecentOrdersModel
        {
            userOrders = await _ordersHandler.GetUserOrders(userid)
        };
        return View(model);
    }
}