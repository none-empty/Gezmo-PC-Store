using Gezmo_PC_Store.DataBaseModels;
using Gezmo_PC_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Gezmo_PC_Store.Services;

public class OrdersHandler: IOrdersHandler
{
private readonly StoreDbContext _context;
private readonly NextOrderID _nextOrderID;
private readonly NextOrderDetailID _nextOrderDetailID;
    public OrdersHandler(StoreDbContext context, NextOrderID nextOrderID, NextOrderDetailID nextOrderDetailID )
    {
       _context = context; 
       _nextOrderID = nextOrderID;
       _nextOrderDetailID = nextOrderDetailID;
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

    public async void InsertOrder(Cart userOrder,int userid)
    {
        long temp = _nextOrderID.GetNextOrderId();
        await _context.Orders.AddAsync(new Order
        {
            OrderId =temp,
            OrderDate =DateOnly.FromDateTime(DateTime.Now),
            Status = "Pending",
            UserId = userid,
            TotalPrice = (int)userOrder.Total()
        });
     List<OrderDetail> orderDetails = Enumerable.Empty<OrderDetail>().ToList();
     foreach (var it in userOrder.Items)
     {
         orderDetails.Add(new OrderDetail
         {
             OrderId = temp,
             OrderDetailId = _nextOrderDetailID.GetNextOrderDetailId(),
             ProductId = it.item.ProductID,
             Quantity = it.quantity,
             Price =(int) it.item.Price,
         });
     }
      await _context.OrderDetails.AddRangeAsync(orderDetails);
      _context.SaveChanges();
    }
}