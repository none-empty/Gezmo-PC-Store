namespace Gezmo_PC_Store.Models;

public class Item
{
    public int ProductID { get; set; }=-1;
    public string ProductName { get; set; }=string.Empty;
    public decimal Price { get; set; }=0;
    public string ImageUrl { get; set; }=string.Empty;
}