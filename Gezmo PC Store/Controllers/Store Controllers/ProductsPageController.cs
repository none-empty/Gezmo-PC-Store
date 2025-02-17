using Gezmo_PC_Store.DataBaseModels;
using Gezmo_PC_Store.Models;
using Gezmo_PC_Store.Services;
using Microsoft.AspNetCore.Mvc;
using Gezmo_PC_Store.Services;
namespace Gezmo_PC_Store.Controllers.Store_Controllers;

public class ProductsPageController:BaseController
{
    private readonly Dictionary<string, Func<int, int,Task<List<Product>>>> TYPES;
    private readonly int PAGINATION_LENGTH=10;
    public ProductsPageController(IGlobalsHelper globalsHelper, IDataProvider dataProvider) : base(globalsHelper, dataProvider)
    {
        TYPES = new Dictionary<string, Func<int, int,Task<List<Product>>>>()
        {
            {"AllProducts",_dataProvider.GetProductsAsync},
            {"MostRecent",_dataProvider.GetMostRecentAsync},
            {"BestSeller",_dataProvider.GetBestSellerAsync}
        };
    }

    public IActionResult ProductsPage(string type,int page = 1,string category=null)
    {
        --page;
        List<Product>products = type.Equals("Category")?
            _dataProvider.GetByCategoryAsync(page*PAGESIZE,PAGESIZE,category).Result:
            TYPES[type](page,PAGESIZE).Result;
        
        return View(new ProductsPageModel{Products=products,PageSize = PAGESIZE,Type = type,PaginationLength = PAGINATION_LENGTH });
    }
}