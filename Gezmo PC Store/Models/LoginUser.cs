using System.ComponentModel.DataAnnotations;

namespace Gezmo_PC_Store.Models;

public class LoginUser
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}