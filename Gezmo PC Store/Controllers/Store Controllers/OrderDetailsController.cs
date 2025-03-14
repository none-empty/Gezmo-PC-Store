using Gezmo_PC_Store.Models;
using Gezmo_PC_Store.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gezmo_PC_Store.Controllers.Store_Controllers;

public class OrderDetailsController:BaseController
{
    private readonly IOrdersHandler _ordersHandler;
    public OrderDetailsController(IGlobalsHelper globalsHelper, IDataProvider dataProvider,IOrdersHandler ordersHandler) : base(globalsHelper, dataProvider)
    {
        _ordersHandler = ordersHandler;
    }

    public IActionResult OrderDetails()
    {
        return View();
    }

    public IActionResult ConfirmOrder()
    {
        var glb = _globalsHelper.FetchGlobals(HttpContext);
        if (!glb.LoggedIn)
        {
            return RedirectToAction("Login", "LoginRegister");
        }
        _ordersHandler.InsertOrder(glb.cart, glb.User!.UserId);
        glb.cart = new Cart();
        _globalsHelper.SetGlobals(HttpContext,glb);
        return RedirectToAction("RecentOrders", "RecentOrders");
    }
}