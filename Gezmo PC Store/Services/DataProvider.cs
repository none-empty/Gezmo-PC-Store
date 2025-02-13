using Gezmo_PC_Store.DataBaseModels;

namespace Gezmo_PC_Store.Services;

public class DataProvider:IDataProvider
{
    public async Task<List<Product>> GetProductsAsync(int start, int quantity)
    {
        List<Product> products = new List<Product>();
         await using (var context = new StoreDbContext())
        {
         products=context.Products.Skip(start).Take(quantity).ToList();
         
        }
       return products;
    }

    public async Task<List<Product>> GetMostRecentAsync(int start, int quantity)
    {
        List<Product> products = new List<Product>();
        await using (var context = new StoreDbContext())
        {
            products = context.Products.
                OrderByDescending(e => e.InsertionDate).
                Skip(start).Take(quantity).
                ToList();
        }

        return products;
    }

    public async Task<List<Product>> GetBestSellerAsync(int start, int quantity)
    {
        List<Product> products = new List<Product>();
        await using (var context = new StoreDbContext())
        {
            products=context.Products.
                OrderByDescending(e=>e.Sold).
                Skip(start).Take(quantity).ToList();   
        }
        return products;
    }

    public async Task<List<Product>> GetByCategoryAsync(int start, int quantity, string category)
    {
        List<Product> products = new List<Product>();
        await using (var context = new StoreDbContext())
        {
            products=context.Products.
                Where(e =>  e.Category.Name == category).
                Skip(start).Take(quantity).ToList();   
        }
        return products;
    }

    public async Task<Product> GetByIdAsync(int ID)
    {
        Product product = new Product();
        await using (var context = new StoreDbContext())
        {
            product=context.Products.SingleOrDefault(e=>e.ProductId == ID);
        }

        return product;
    }
}