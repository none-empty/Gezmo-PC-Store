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
    private readonly int CHANGELIMIT=2;
    private readonly int CHANGEVALUE=2;
    public ProductsPageController(IGlobalsHelper globalsHelper, IDataProvider dataProvider) : base(globalsHelper, dataProvider)
    {
        TYPES = new Dictionary<string, Func<int, int,Task<List<Product>>>>()
        {
            {"AllProducts",_dataProvider.GetProductsAsync},
            {"MostRecent",_dataProvider.GetMostRecentAsync},
            {"BestSeller",_dataProvider.GetBestSellerAsync}
        };
    }

    public async Task<IActionResult> ProductsPage(string type,int page = 1,int pageFromLeft=1,string? category=null)
    {
        int len = await _dataProvider.GetProductsCountAsync(type, category);
        int maxPage = len /PAGESIZE +(len % PAGESIZE== 0 ? 0 : 1);
        Validate_Page(ref page, maxPage);
         
        List<Product>products = type.Equals("Category")?
            await _dataProvider.GetByCategoryAsync( (page-1)*PAGESIZE,PAGESIZE,category!) :
            await TYPES[type]((page-1)*PAGESIZE,PAGESIZE);

        pageFromLeft=PaginationScopeShouldChange(page, pageFromLeft);
        
        ProductsPageModel model = new ProductsPageModel
        {
            Products = products,
            PageSize = PAGESIZE, Type = category is null ? type : category,
            PaginationLength = PAGINATION_LENGTH,
            PageFromLeft = pageFromLeft,
            CurrentPage = page,
            Category = category
        };
      
        model.PageFromRight = int.Min(pageFromLeft+PAGINATION_LENGTH,maxPage);
        return View(model);
    }

    public void Validate_Page(ref int page, int maxPage)
    {
        if (page > maxPage)
        {
            page = maxPage;
        }
        if(page <1)
        {
            page = 1;
        }
       
    }
    public int PaginationScopeShouldChange(int currentPage,int pageFromLeft)
    {
        if (PaginationScopeShouldIncrease(currentPage, pageFromLeft)) return pageFromLeft + CHANGEVALUE;
        if(PaginationScopeShouldDecrease(currentPage, pageFromLeft)) return pageFromLeft-CHANGEVALUE;
        return pageFromLeft;
    }
    public bool PaginationScopeShouldIncrease(int currentPage,int pageFromLeft)
    {
        return pageFromLeft + PAGINATION_LENGTH - currentPage - 1 <= CHANGELIMIT;
    }
    public bool PaginationScopeShouldDecrease(int currentPage,int pageFromLeft)
    {
        return pageFromLeft-CHANGEVALUE > 0 && currentPage-pageFromLeft<=CHANGELIMIT;
    }
}