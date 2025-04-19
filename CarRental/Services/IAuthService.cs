using CarRental.Models;
using CarRental.ViewModels;

namespace CarRental.Services
{
    public interface IAuthService
    {
        BaseUser? GetUser<T>() where T : BaseUser;
        int? GetUserId();
        bool IsUserLoggedIn();
        Task<bool> Login(string email, string password);
        void Logout();
        Task Register(RegisterViewModel model);
        //Task<BaseUser?> GetTrackedUser();
    }
}
