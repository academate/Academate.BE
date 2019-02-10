using Domain.Entities;

namespace Application.Services.AccessControl
{
    public interface IAuthenticationService
    {
        User Authenticate(string username, string password);
    }
}