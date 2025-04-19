using CarRental.Data;
using CarRental.Data.Interfaces;
using CarRental.Models;
using CarRental.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CarRental.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _accessor;     
        private readonly IBaseUser _baseUserRepository;
        private readonly ApplicationDbContext _context;
        
        public AuthService(IHttpContextAccessor accessor, IBaseUser baseUserRepository, ApplicationDbContext context)
        {
            _accessor = accessor;
            _baseUserRepository = baseUserRepository;
            _context = context;
        }

        public BaseUser? GetUser<T>() where T : BaseUser
        {
            return _accessor?.HttpContext?.Session.GetObject<T>("User") as BaseUser;
        }

        //public async Task<BaseUser?> GetTrackedUser()
        //{
        //    var id = GetUserId();
        //    if (id == null)
        //    {
        //        return default;
        //    }

        //    return await _baseUserRepository.GetUserWithProfile();
        //}

        public int? GetUserId()
        {
            return _accessor?.HttpContext?.Session?.GetObject<Customer>("User")?.Id;
        }

        public bool IsUserLoggedIn()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Login(string email, string password)
        {
            var user = await _baseUserRepository.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                return false;
            }

            _accessor?.HttpContext?.Session.Set<dynamic>("User", user);
            return true;
        }

        public void Logout()
        {
            _accessor?.HttpContext?.Session.Clear();
        }

        public async Task Register(RegisterViewModel model)
        {
            BaseUser user;
            
            var newUser = new BaseUser { FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password};

            await _baseUserRepository.AddAsync(newUser);
        }
    }
}
