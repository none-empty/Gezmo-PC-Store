using Microsoft.AspNetCore.Identity;

namespace Gezmo_PC_Store.Models;

public class UserProfile  
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
     
}