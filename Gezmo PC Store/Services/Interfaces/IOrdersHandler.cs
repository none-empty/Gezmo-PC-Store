using Gezmo_PC_Store.Models;

namespace Gezmo_PC_Store.Services;

public interface IOrdersHandler
{
    public Task<List<UserOrder>>GetUserOrders(int userId);
    public void InsertOrder(Cart userOrder,int userid);
}