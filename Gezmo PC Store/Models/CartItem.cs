namespace Gezmo_PC_Store.Models;

public class CartItem
{
    public Item item = new Item();
    public int quantity=0;
    public double get_total() => item.Price * quantity;
}