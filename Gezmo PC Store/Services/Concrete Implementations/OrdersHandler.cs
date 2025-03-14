using Gezmo_PC_Store.DataBaseModels;
using Gezmo_PC_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Gezmo_PC_Store.Services;

public class OrdersHandler: IOrdersHandler
{
private readonly StoreDbContext _context;
    public OrdersHandler(StoreDbContext context)
    {
       _context = context; 
    }
    public async Task<List<UserOrder>> GetUserOrders(int userId)
    {
        var userOrders = await _context.Orders.Where(e=>e.UserId == userId)
            .Select(e => new UserOrder
        {
            OrderId = e.OrderId,
            OrderDate = e.OrderDate,
            Status = e.Status,
            TotalPrice = e.TotalPrice
        }).ToListAsync();
        
        return userOrders ;
    }
}