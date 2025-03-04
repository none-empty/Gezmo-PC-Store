using System.ComponentModel.DataAnnotations;

namespace Gezmo_PC_Store.Models;

public class RegisterUser
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(20, ErrorMessage = "Username must be between 5 and 20 characters.", MinimumLength = 1)]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")] 
    public string Email { get; set; }
    
    
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, ErrorMessage = "Password must be at least 6 characters.", MinimumLength = 1)]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
}