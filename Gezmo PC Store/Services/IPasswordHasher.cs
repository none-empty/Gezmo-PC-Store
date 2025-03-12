namespace Gezmo_PC_Store.Services;

public interface IPasswordHasher
{
    public string HashPassword(string password);
}