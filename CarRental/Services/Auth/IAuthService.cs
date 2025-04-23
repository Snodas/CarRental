using CarRental.Models;
using CarRental.ViewModels;

namespace CarRental.Services.Auth
{
    public interface IAuthService
    {
        BaseUser? GetUser<T>() where T : BaseUser;
        int? GetUserId();
        bool IsUserLoggedIn();
        Task<bool> Login(string email, string password);
        void Logout();
        Task Register(RegisterViewModel model);
    }
}
