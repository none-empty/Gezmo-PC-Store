using Gezmo_PC_Store.DataBaseModels;

namespace Gezmo_PC_Store.Services;

public class DataProvider:IDataProvider
{
    public async Task<List<Product>> GetProducts<T1,T2>(int start, int end,Func<Product,T1>?filter=null,Func<Product,T2>?comparer=null)
    {
       return await this.FetchProductsAsync(start, end,filter,comparer);
    }
}