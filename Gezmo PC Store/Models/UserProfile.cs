using Microsoft.AspNetCore.Identity;

namespace Gezmo_PC_Store.Models;

public class UserProfile  
{
    private int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
     
}