using Gezmo_PC_Store.DataBaseModels;
using Gezmo_PC_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Gezmo_PC_Store.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
    [HttpPost]
    public async Task<IActionResult> Login(LoginUser loginUser)
    {
        var user= await _userInfo.GetUserByEmail(loginUser.Email);
        var hp = _passwordHasher.HashPassword(null, loginUser.Password);
        if (user is null || !(user.PasswordHash.Equals(hp)))
        {
            ModelState.AddModelError("Email", "Invalid email or password");
            return View(loginUser);
        }
        sign_in(user);
        return RedirectToAction("Main", "Main");
    }
    
[HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
[HttpPost]
    public async Task<IActionResult> Register(RegisterUser user)
    {
       await validate(ModelState, user);
        if (!ModelState.IsValid)
        {
            return View(user);
        }
        var record=new User{UserId = counter++,UserName = user.UserName,Email = user.Email,Role = "user"};
         record.PasswordHash = _passwordHasher.HashPassword(null,user.Password);
         _userInfo.InsertUserAsync(record);
         sign_in(record);
         return RedirectToAction("Main", "Main");
    }

    public async Task validate(ModelStateDictionary ModelState,RegisterUser user)
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
    }
    public void sign_in(User user)
    {
        var mdl = _globalsHelper.FetchGlobals(HttpContext);
        mdl.LoggedIn = true;
        mdl.User = new UserProfile { Username = user.UserName, Email = user.Email,UserId = user.UserId };
        _globalsHelper.SetGlobals(HttpContext,mdl);
    }

    public IActionResult Sign_Out()
    {
        var glb=_globalsHelper.FetchGlobals(HttpContext);
        glb.LoggedIn = false;
        glb.User = null;
        _globalsHelper.SetGlobals(HttpContext,glb);
        return RedirectToAction("Main", "Main");
    }
}