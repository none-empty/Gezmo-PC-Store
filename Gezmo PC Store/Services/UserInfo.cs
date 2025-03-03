using Gezmo_PC_Store.DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace Gezmo_PC_Store.Services;

public class UserInfo:IUserInfo
{
    private readonly StoreDbContext _context;
    public UserInfo(StoreDbContext context)
    {
        _context = context;
    }
    
}