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
        MainModel mainModel = new MainModel
        {
            AllProducts = _dataProvider.GetProductsAsync(0, 8).Result,
            BestSeller = _dataProvider.GetBestSellerAsync(0, 4).Result,
            MostRecent = _dataProvider.GetMostRecentAsync(0, 4).Result
        };

        return View(mainModel);
    }
}