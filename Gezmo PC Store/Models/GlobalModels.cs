namespace Gezmo_PC_Store.Models;

public class GlobalModels
{
    public Cart cart { get; set; } = new();
    public bool LoggedIn { get; set; } = false;
    public UserProfile? User { get; set; } =null;
}