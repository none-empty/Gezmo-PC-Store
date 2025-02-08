using Gezmo_PC_Store.DataBaseModels;

namespace Gezmo_PC_Store.Services;

public static class ProductsFetch
{
    public static async Task<List<Product>> FetchProductsAsync<T1,T2>(this DataProvider dataProvider,int start,int end,Func<Product,T1>?filter=null,Func<Product,T2>?comparer=null)
    {
        return new List<Product>();
    } 
}