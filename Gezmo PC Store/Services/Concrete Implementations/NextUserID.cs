using Gezmo_PC_Store.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace Gezmo_PC_Store.Services;

public class NextUserID
{
    
    private static readonly object _lockObject = new object();
    private static int _nextUserID;
    public NextUserID(IServiceProvider services)
    {
        InitializeNextUserID(services);
    }

    private void InitializeNextUserID(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            _nextUserID = context.Users.Max(e=>e.UserId);
        }
        
    }

    public int GetNextUserId()
    {
        int current = 0;
        lock (_lockObject)
        {
            current = _nextUserID;
             _nextUserID++;
        }
        
        return current;
    }
 
}