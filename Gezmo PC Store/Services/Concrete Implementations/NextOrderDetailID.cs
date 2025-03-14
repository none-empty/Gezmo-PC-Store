using Gezmo_PC_Store.DataBaseModels;

namespace Gezmo_PC_Store.Services;

public class NextOrderDetailID
{
    private static readonly object _lockObject = new object();
    private static long _nextOrderDetailID;
    public NextOrderDetailID(IServiceProvider services)
    {
        InitializeNextUserID(services);
    }

    private void InitializeNextUserID(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            _nextOrderDetailID = context.OrderDetails.Any()? context.OrderDetails.Max(e=>e.OrderDetailId):1;
            
        }
        
    }

    public long GetNextOrderDetailId()
    {
        long current = 0;
        lock (_lockObject)
        {
            current = _nextOrderDetailID;
            _nextOrderDetailID++;
        }
        
        return current;
    }
}