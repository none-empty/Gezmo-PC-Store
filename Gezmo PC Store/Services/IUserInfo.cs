using Gezmo_PC_Store.DataBaseModels;

namespace Gezmo_PC_Store.Services;

public interface IUserInfo
{
 public Task<bool> CheckIfEmailUnique(string email);
 public Task<bool> CheckIfUsernameUnique(string username);
 public void insertUserAsync(User user);
}