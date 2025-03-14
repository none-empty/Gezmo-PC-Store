namespace Gezmo_PC_Store.Models;

public class UserOrder
{
    public long OrderId { get; set; }
    public int TotalPrice { get; set; }

    public DateOnly OrderDate { get; set; }
    public string? Status { get; set; }
}