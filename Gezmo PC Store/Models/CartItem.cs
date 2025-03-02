namespace Gezmo_PC_Store.Models;

public class CartItem
{
    public Item item { get; set; } = new Item();
    public int quantity{ get; set; }=0;
    public double get_total() =>  Convert.ToDouble(String.Format("{0:0.00}",item.Price * quantity ));
}