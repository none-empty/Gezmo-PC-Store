using Gezmo_PC_Store.DataBaseModels;
using Gezmo_PC_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Gezmo_PC_Store.Services;
using Microsoft.AspNetCore.Identity;

namespace Gezmo_PC_Store.Controllers.Store_Controllers;

public class LoginRegisterController:BaseController
{
    private readonly IUserInfo _userInfo;
    private readonly IPasswordHasher<User> _passwordHasher;
    private int counter = 2;
    public LoginRegisterController(IGlobalsHelper globalsHelper,
        IDataProvider dataProvider
        ,IUserInfo userInfo,
        IPasswordHasher<User>passwordHasher) : base(globalsHelper,
        dataProvider)
    {
       _userInfo = userInfo; 
       _passwordHasher = passwordHasher;
    }
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
[HttpPost]
    public async Task<IActionResult> Register(RegisterUser user)
    {
        if (! await _userInfo.CheckIfEmailUnique(user.Email))
        {
            ModelState.AddModelError("Email", "This email is already in use.");
        }
        if (!await _userInfo.CheckIfUsernameUnique(user.UserName))
        {
            ModelState.AddModelError("UserName", "This username is already in use.");
        }

        if (!user.Password.Equals(user.ConfirmPassword))
        {
            ModelState.AddModelError("ConfirmPassword", "password doesn't match."); 
        }
        if (!ModelState.IsValid)
        {
            return View(user);
        }
        var record=new User{UserId = counter++,UserName = user.UserName,Email = user.Email,Role = "user"};
         record.PasswordHash = _passwordHasher.HashPassword(record,user.Password);
         
         _userInfo.insertUserAsync(record);

         return RedirectToAction("Main", "Main");
    }
}