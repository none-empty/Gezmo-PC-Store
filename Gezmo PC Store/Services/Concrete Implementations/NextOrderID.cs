using Gezmo_PC_Store.DataBaseModels;

namespace Gezmo_PC_Store.Services;

public class NextOrderID
{
    private static readonly object _lockObject = new object();
    private static long _nextOrderID;
    public NextOrderID(IServiceProvider services)
    {
        InitializeNextOrderID(services);
    }

    private void InitializeNextOrderID(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            _nextOrderID = context.Orders.Any()?context.Orders.Max(e=>e.OrderId):1;
        }
        
    }

    public long GetNextOrderId()
    {
        long current = 0;
        lock (_lockObject)
        {
            current = _nextOrderID;
            _nextOrderID++;
        }
        
        return current;
    }
}