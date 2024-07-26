using Core.Domain.Enums;
using Core.Services.ServiceExtension;

namespace Core.Services.ServiceClasses;

public interface IUserAuthenticationService
{
    Task<string> Login(UserAuthentication userAuthentication);
    Task Register(UserRegistration userRegistration);
}