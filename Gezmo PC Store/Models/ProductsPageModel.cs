using Gezmo_PC_Store.DataBaseModels;

namespace Gezmo_PC_Store.Models;

public class ProductsPageModel
{
    public List<Product> Products { get; set; } = Enumerable.Empty<Product>().ToList();
    public int PageSize { get; set; } = 1;
    public string Type { get; set; } = null!;
    public int Category { get; set; } = -1;
    public int CurrentPage { get; set; } = 1;
    public int PageFromLeft { get; set; } = 1;
    public int PaginationLength { get; set; } = 10;
    public int PageFromRight { get; set; }
}