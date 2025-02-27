using Gezmo_PC_Store.DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace Gezmo_PC_Store.Services;

public class DataProvider:IDataProvider
{
    private readonly StoreDbContext _context;
    private const int QUANTITY_LIMIT = 72;
    public DataProvider(StoreDbContext context)
    {
       _context = context; 
    }
    public async Task<List<Product>> GetProductsAsync(int start, int quantity)
    {
        return await _context.Products.Skip(start).Take(quantity).ToListAsync();
    }

    public async Task<List<Product>> GetMostRecentAsync(int start, int quantity)
    { 
        return await  _context.Products.
                OrderByDescending(e => e.InsertionDate).
                Skip(start).Take(quantity).
                ToListAsync();
    }

    public async Task<List<Product>> GetBestSellerAsync(int start, int quantity)
    {
        return await _context.Products.
                OrderByDescending(e=>e.Sold).
                Skip(start).Take(quantity).ToListAsync();
    }

    public async Task<List<Product>> GetByCategoryAsync(int start, int quantity, string category)
    {
        return await _context.Products.
                Where(e =>  e.Category.Name == category).
                Skip(start).Take(quantity).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.SingleOrDefaultAsync(e=>e.ProductId == id);
    }

    public async Task<int> GetProductsCountAsync(string type,string? category=null)
    {
        if(type.ToLower().Equals("allproducts"))
          return await _context.Products.CountAsync();
        if(type.ToLower().Equals("category")) 
            return await _context.Products.
                Where(e => e.Category.Name == category).CountAsync();
        return QUANTITY_LIMIT;
    }
}