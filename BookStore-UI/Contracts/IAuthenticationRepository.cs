using System.Threading.Tasks;
using BookStore_UI.Models;

namespace BookStore_UI.Contracts
{
    public interface IAuthenticationRepository
    {
        Task<bool> Register(RegistrationModel user);

        Task<bool> Login(LoginModel user);

        Task Logout();
    }
}
