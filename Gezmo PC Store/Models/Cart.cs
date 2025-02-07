namespace Gezmo_PC_Store.Models;

public class Cart
{
    public List<CartItem> Items { get; set; } = new List<CartItem>();

    public double Total()
    {
        double total = 0;
        foreach (var cart_item in Items) total += cart_item.get_total();
        return total;
    }
    public bool IsEmpty()=> Items == null || Items.Count == 0;
}