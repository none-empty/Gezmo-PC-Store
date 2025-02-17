using Gezmo_PC_Store.DataBaseModels;

namespace Gezmo_PC_Store.Models;

public class ProductsPageModel
{
    public List<Product> Products { get; set; } = Enumerable.Empty<Product>().ToList();
}