namespace Gezmo_PC_Store.Models;

public class Cart
{
    public List<CartItem> Items { get; set; } = new List<CartItem>();

    public double Total()
    {
       return Items.Sum(e => e.get_total());
    }
    public bool IsEmpty()=> Items.Count == 0;
}