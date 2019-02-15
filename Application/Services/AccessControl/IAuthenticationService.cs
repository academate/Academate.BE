using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Services.AccessControl
{
    public interface IAuthenticationService
    {
        Task<User> Authenticate(string username, string password);
    }
}