namespace Gezmo_PC_Store.Models;

public class CartItem
{
    public Item item { get; set; } = new Item();
    public int quantity{ get; set; }=0;
    public double get_total() => (double)item.Price * quantity;
}