using Gezmo_PC_Store.DataBaseModels;

namespace Gezmo_PC_Store.Services;

public interface IDataProvider
{
    public Task<List<Product>> GetProductsAsync(int start,int quantity);
    public Task<List<Product>> GetMostRecentAsync(int start,int quantity);
    public Task<List<Product>> GetBestSellerAsync(int start,int quantity);
    public Task<List<Product>> GetByCategoryAsync(int start,int quantity,int category_num);
    public Task<Product?> GetByIdAsync(int id);
    public Task<int>GetProductsCountAsync(string type,int category_num);
    public Task<List<Category>> GetCategoriesAsync();
}