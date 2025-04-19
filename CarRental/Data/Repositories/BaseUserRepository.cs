using CarRental.Data.Interfaces;
using CarRental.Models;

namespace CarRental.Data.Repositories
{
    public class BaseUserRepository : GenericRepository<BaseUser, ApplicationDbContext>, IBaseUser
    {
        public BaseUserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
