namespace Core.Services.ServiceClasses;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyPassword(string inputPassword, string hashedPassword);
}