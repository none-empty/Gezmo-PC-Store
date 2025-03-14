using Gezmo_PC_Store.DataBaseModels;
using Gezmo_PC_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Gezmo_PC_Store.Services;

public class UserInfo:IUserInfo
{
    private readonly StoreDbContext _context;
    public UserInfo(StoreDbContext context)
    {
        _context = context;
    }

   
    public async Task<bool> CheckIfEmailUnique(string email)
    {
       return !await _context.Users.AnyAsync(x => x.Email.Equals(email));
    }

    public async Task<bool> CheckIfUsernameUnique(string username)
    {
        return ! await _context.Users.AnyAsync(x => x.UserName == username);
    }

    public async void InsertUserAsync(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
    }
}