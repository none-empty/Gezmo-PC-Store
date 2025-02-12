using Gezmo_PC_Store.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gezmo_PC_Store.Controllers.Store_Controllers;

public class ProductDetailsPageController:BaseController
{
    public ProductDetailsPageController(IGlobalsHelper globalsHelper, IDataProvider dataProvider) : base(globalsHelper, dataProvider)
    {
    }

    public IActionResult ProductDetails()
    {
        return View();
    }
}